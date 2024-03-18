using FundHubAPI.Data.DTOs;
using FundHubAPI.Data.Models;

namespace FundHubAPI.Services.Repositories.UsersRepository;

public interface IUserRepository
{
    public Task<UserDTO> GetUser(string userid);
    public Task<List<UserDTO>> GetUers();
    public Task<bool> AddUser(UserDTO usertoadd);
    public Task CreateFolders();
    public Task<bool> UpdateUser(UserDTO usertoupdate);
    public Task<bool> RemoveUser(string userid);
}