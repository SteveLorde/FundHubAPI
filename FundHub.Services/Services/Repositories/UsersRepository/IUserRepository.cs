using FundHub.Data.Data.DTOs;
using FundHub.Data.Data.Models;

namespace FundHub.Services.Services.Repositories.UsersRepository;

public interface IUserRepository
{
    public Task<UserDTO> GetUser(string userid);
    public Task<UserDTO> GetUserByName(string username);
    public Task<bool> CheckUser(string username);
    public Task<User> GetUserDirect(string userid);
    public Task<List<UserDTO>> GetUers();
    public Task<bool> AddUser(UserDTO usertoadd);
    public Task CreateFolders();
    public Task<bool> UpdateUser(UserDTO usertoupdate);
    public Task<bool> RemoveUser(string userid);
}