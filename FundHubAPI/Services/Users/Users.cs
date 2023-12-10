using FundHubAPI.Data;
using FundHubAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FundHubAPI.Services.Users;

class Users : IUsers
{
    
    private readonly DataContext _db;
    private readonly IWebHostEnvironment _hostingenv;

    public Users(DataContext db, IWebHostEnvironment hostenv)
    {
        _db = db;
        _hostingenv = hostenv;
    }
    
    public async Task CreateFolders()
    {
        try
        {
            List<User> allusers = await _db.Users.ToListAsync();
            foreach (User user in allusers)
            {
                var usersfoldertocreate = Path.Combine(_hostingenv.ContentRootPath, "Storage", "Users",
                    $"{user.Id}", "Images");
                Directory.CreateDirectory(usersfoldertocreate); 
            }
            Console.WriteLine("Created users assets folders successfully");
        }
        catch (Exception err)
        {
            throw err;
        }
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await _db.Users.ToListAsync();
    }

    public async Task UpdateUser(User user)
    {
        var selecteduser = await _db.Users.FirstAsync(databaseuser => databaseuser.Id == user.Id);
        {
            selecteduser.email = user.email;
            selecteduser.facebook = user.facebook;
            selecteduser.usertype = user.usertype;
            selecteduser.phonenumber = user.phonenumber;
            selecteduser.x_socialmedia = user.x_socialmedia;
            selecteduser.instagram = user.instagram;
        }
        await _db.SaveChangesAsync();

    }

    public async Task RemoveUser(string userid)
    {
        var userguid = Guid.Parse(userid);
        var selecteduser = await _db.Users.FirstAsync(x => x.Id == userguid);
        _db.Remove(selecteduser);
        await _db.SaveChangesAsync();
    }
    
}