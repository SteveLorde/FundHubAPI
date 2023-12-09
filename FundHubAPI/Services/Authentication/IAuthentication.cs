using FundHubAPI.Data.DTOs;
using FundHubAPI.Data.Models;

namespace API.Services.Authentication;

public interface IAuthentication
{
    public Task<string> Login(UserDTO usertologin);
    public Task<bool> Register(UserDTO usertoregister);
    public Task<User> GetUserInfo(AuthRequestDTO request);
}