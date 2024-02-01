using AutoMapper;
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
    private readonly IWebHostEnvironment _hostenv;

    public UserRepository(DataContext db, IMapper mapper, IWebHostEnvironment hostingEnvironment)
    {
        _mapper = mapper;
        _db = db;
        _hostenv = hostingEnvironment;
    }


    public async Task<UserDTO> GetUser(string userid)
    {
        return await _db.Users.Include(u => u.projects).ProjectTo<UserDTO>(_mapper.ConfigurationProvider).FirstAsync(u => u.Id == Guid.Parse(userid));
    }

    public async Task<List<UserDTO>> GetUers()
    {
        return await _db.Users.Include(u => u.projects).ProjectTo<UserDTO>(_mapper.ConfigurationProvider).ToListAsync();
    }

    public async Task AddUser(UserDTO usertoadd)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateUser(UserDTO usertoupdate)
    {
        throw new NotImplementedException();
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
}