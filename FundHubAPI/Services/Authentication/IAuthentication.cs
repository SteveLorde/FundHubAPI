using FundHubAPI.Data.DTOs;
using FundHubAPI.Data.Models;

namespace FundHubAPI.Services.Authentication;

public interface IAuthentication
{
    public Task<string> Login(UserDTO usertologin);
    public Task<string> LoginTest();
    public Task<bool> Register(UserDTO usertoregister);
    public Task<User> GetUser(string userid);
}