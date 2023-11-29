using API.Services.Authentication;
using API.Services.JWT;
using FundHubAPI.Data.DTOs;
using FundHubAPI.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace FundHubAPI.Controllers;

[ApiController]
[Route("Authentication")]
public class AuthenticationController : Controller
{
    private readonly IAuthentication _auth;
    private readonly IJWT _jwt;

    public AuthenticationController(IAuthentication auth, IJWT jwt)
    {
        _auth = auth;
        _jwt = jwt;
    }
    
    
    [HttpPut("Login")]
    public async Task<bool> Login(UserDTO loginrequest)
    {
        return await _auth.Login(loginrequest);
    }
    
    [HttpPut("Register")]
    public async Task<bool> Register(UserDTO registerrequest)
    {
        return await _auth.Register(registerrequest);
    }
    
    [HttpPut("GetUserInfo")]
    public async Task<User> GetUserInfo(AuthRequestDTO inforequest)
    {
        return await _auth.GetUserInfo(inforequest);
    }

    [HttpPut("CheckToken")]
    public async Task<bool> CheckToken(string token)
    {
        var check = _jwt.VerifyToken(token);
            if (check)
            {
                return true;
            }
            else
            {
                return false;
            }
    }
    
}