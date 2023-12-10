using FundHubAPI.Data.Models;

namespace FundHubAPI.Services.Users;

public interface IUsers
{
    public Task CreateFolders();
    public Task<List<User>> GetAllUsers();
    public Task UpdateUser(User user);
    public Task RemoveUser(string userid);
}