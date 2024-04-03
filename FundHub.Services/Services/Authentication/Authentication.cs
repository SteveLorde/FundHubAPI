using AutoMapper;
using FundHub.Data.Data;
using FundHub.Data.Data.DTOs;
using FundHub.Data.Data.DTOs.RequestDTO;
using FundHub.Services.Services.JWT;
using FundHub.Services.Services.JWT.DTO;
using FundHub.Services.Services.PasswordHash;
using FundHub.Services.Services.Repositories.UsersRepository;
using Microsoft.EntityFrameworkCore;

namespace FundHub.Services.Services.Authentication;

public class Authentication : IAuthentication
{
    private readonly DataContext _db;
    private readonly IJWT _jwtservice;
    private IMapper _mapper;
    private readonly IPasswordHash _passwordhash;
    private readonly IUserRepository _usersrepo;

    public Authentication(DataContext db, IJWT jwtservice, IMapper mapper, IPasswordHash passwordhash, IUserRepository usersrepo)
    {
        _db = db;
        _jwtservice = jwtservice;
        _mapper = mapper;
        _passwordhash = passwordhash;
        _usersrepo = usersrepo;
    }
    
    public async Task<string> Login(LoginRequestDTO loginreq)
    {
        string token = "";
        //1st, check username in database
        bool checkuser = await _db.Users.AnyAsync(x => x.Username == loginreq.Username);
        if (!checkuser)
        {
            return "username / password are wrong";
        }
        else
        {
            var loginuser = await _db.Users.FirstAsync(x => x.Username == loginreq.Username);
            JWTRequestDTO userjwtreq = _mapper.Map<JWTRequestDTO>(loginuser);
            //2nd verify password
            bool checkpassword = await VerifyPassword(loginreq.Password, loginuser.Hashedpassword) ;
            if (checkpassword)
            {
                token  = _jwtservice.CreateToken(userjwtreq);
                return token;
            }
            else
            {
                return "username / password are wrong";
            }
        }
    }


    public async Task<bool> Register(RegisterRequestDTO registerreq)
    {
        //map a new userdto from authrequest
        UserDTO  newuserdto = _mapper.Map<UserDTO>(registerreq);
        //1-hash password
        string hashedpassword =  _passwordhash.CreateHashedPassword(newuserdto.Hashedpassword);
        //2-assign password
        newuserdto.Hashedpassword = hashedpassword;
        //3-add to database
        return await _usersrepo.AddUser(newuserdto);
    }

    private async Task<bool> VerifyPassword(string passwordtoverify, string hashedpassword)
    {
        //1-extract salt from database user hashedpassword, pass string pattern SALT.HASHEDPASSWORD
        var extractedsavedpassword = hashedpassword.Split(".");
        var extractedsalt = extractedsavedpassword[0];
        var extractedhashedpass = extractedsavedpassword[1];
        //2-generate hashed password with given salt
        var passwordtotest = _passwordhash.HashPasswordWithGivenSalt( extractedsalt, passwordtoverify);
        //3-compare
        if (passwordtotest == extractedhashedpass)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
}