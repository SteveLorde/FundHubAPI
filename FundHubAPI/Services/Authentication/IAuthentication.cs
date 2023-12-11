using FundHubAPI.Data.DTOs;
using FundHubAPI.Data.Models;

namespace API.Services.Authentication;

public interface IAuthentication
{
    public Task<LoginResponseDTO?> Login(UserDTO usertologin);
    public Task<string> LoginTest();
    public Task<bool> Register(UserDTO usertoregister);
    public Task<User> GetUser(string userid);
}