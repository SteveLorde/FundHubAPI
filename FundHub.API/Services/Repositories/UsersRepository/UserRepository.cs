﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using FundHubAPI.Data;
using FundHubAPI.Data.DTOs;
using FundHubAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FundHubAPI.Services.Repositories.UsersRepository;

class UserRepository : IUserRepository
{
    private readonly IMapper _mapper;
    private readonly DataContext _db;
    private readonly IWebHostEnvironment _webhostenv;

    public UserRepository(DataContext db, IMapper mapper, IWebHostEnvironment webhostenv)
    {
        _mapper = mapper;
        _db = db;
        _webhostenv = webhostenv;
    }


    public async Task<UserDTO> GetUser(string userid)
    {
        return await _db.Users.Include(u => u.Project).ProjectTo<UserDTO>(_mapper.ConfigurationProvider).FirstAsync(u => u.Id == Guid.Parse(userid));
    }

    public async Task<User> GetUserDirect(string userid)
    {
        return await _db.Users.FirstAsync(u => u.Id == Guid.Parse(userid));
    }

    public async Task<List<UserDTO>> GetUers()
    {
        return await _db.Users.Include(u => u.Project).ProjectTo<UserDTO>(_mapper.ConfigurationProvider).ToListAsync();
    }

    public async Task<bool> AddUser(UserDTO usertoadd)
    {
        User newuser = _mapper.Map<User>(usertoadd);
        await _db.Users.AddAsync(newuser);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateUser(UserDTO usertoupdate)
    {
        User querieduser = await _db.Users.Include(u => u.Project).Include(u => u.Donations).FirstAsync(u => u.Id == usertoupdate.Id);
        querieduser = _mapper.Map<User>(usertoupdate);
        _db.Users.Update(querieduser);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RemoveUser(string userid)
    {
        var selecteduser = await _db.Users.FindAsync(Guid.Parse(userid));
        if (selecteduser != null)
        {
            _db.Users.Remove(selecteduser);
            await _db.SaveChangesAsync();
            return true;
        }
        else
        {
            return true;
        }
    }
    
    public async Task CreateFolders()
    {
        try
        {
            List<User> allusers = await _db.Users.ToListAsync();
            foreach (User user in allusers)
            {
                var usersfoldertocreate = Path.Combine(_webhostenv.ContentRootPath, "Storage", "Users",
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
}