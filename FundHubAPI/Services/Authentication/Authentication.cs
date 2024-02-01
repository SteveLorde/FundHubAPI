using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using FundHubAPI.Data;
using FundHubAPI.Data.DTOs;
using FundHubAPI.Data.Models;
using FundHubAPI.Services.Authentication.Model;
using FundHubAPI.Services.JWT;
using Microsoft.EntityFrameworkCore;

namespace FundHubAPI.Services.Authentication;

class Authentication : IAuthentication
{
    private readonly DataContext _db;
    private readonly IJWT _jwtservice;
    private IMapper _mapper;

    public Authentication(DataContext db, IJWT jwtservice, IMapper mapper)
    {
        _db = db;
        _jwtservice = jwtservice;
        _mapper = mapper;
    }
    
    public async Task<string> Login(UserDTO usertologin)
    {
        try
        {
            string token = " ";
            //1st, check username in database
            bool checkuser = await _db.Users.AnyAsync(x => x.username == usertologin.username);
            if (checkuser)
            {
                var loginuser = await _db.Users.FirstAsync(x => x.username == usertologin.username);
                //2nd verify password
                bool checkpassword = await VerifyPassword(usertologin);

                if (checkpassword)
                {
                    token  = _jwtservice.CreateToken(loginuser);
                }
            }
            return token;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<string> LoginTest()
    {
        var testuser = await _db.Users.FirstAsync(user => user.username == "testuser");
        return _jwtservice.CreateToken(testuser);
    }

    public async Task<bool> Register(UserDTO usertoregister)
    {
        try
        {
            //1-hash password
            Hash hashedpassword = await HashPassword(usertoregister);
            //2-create new user
            User newuser = _mapper.Map<User>(usertoregister);
            //3-add to database
            await _db.Users.AddAsync(newuser);
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<User> GetUser(string userid)
    {
        User user = await _db.Users.FirstAsync(x => x.Id == Guid.Parse(userid));
        return user;
    }
    
    
    private async Task<Hash> HashPassword(UserDTO user)
    {
        string salt = GenerateSalt();
        string hashedpassword = GenerateHashedPassword(user.password, salt);
        Hash userhash = new Hash()
        {
            hash = hashedpassword,
            salt = salt
        };
        return userhash;
    }
    
    private string GenerateHashedPassword(string password, string salt)
    {
        byte[] passwordbytes = Encoding.UTF8.GetBytes(password);
        byte[] saltbytes = Convert.FromBase64String(salt);

        byte[] combinedbytes = new byte[saltbytes.Length + passwordbytes.Length];
        Buffer.BlockCopy(saltbytes,0,combinedbytes, 0, saltbytes.Length);
        Buffer.BlockCopy(passwordbytes,0,combinedbytes, saltbytes.Length, passwordbytes.Length);

        SHA256 sha256 = SHA256.Create();
        byte[] hashedbytes = sha256.ComputeHash(combinedbytes);
        string hashedpassword = Convert.ToBase64String(hashedbytes);
        return hashedpassword;
    }

    private async Task<bool> VerifyPassword(UserDTO loginrequest)
    {
        User usertoverfiy = await _db.Users.FirstAsync(x => x.username == loginrequest.username);
        string passwordtoverify = GenerateHashedPassword(loginrequest.password, usertoverfiy.pass_salt);

        if (passwordtoverify == usertoverfiy.hashedpassword)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    private static string GenerateSalt()
    {
        byte[] salt = new byte[16];
        var rng = new RNGCryptoServiceProvider();
        rng.GetBytes(salt);
        string base64salt = Convert.ToBase64String(salt);
        return base64salt;
    }
    
    
    
}