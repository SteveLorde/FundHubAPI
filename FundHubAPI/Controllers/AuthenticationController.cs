using API.Services.Authentication;
using API.Services.JWT;
using FundHubAPI.Data.DTOs;
using FundHubAPI.Data.Models;
using FundHubAPI.Services.JWT;
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

    [HttpPost("Login")]
    public async Task<LoginResponseDTO?> Login(UserDTO loginrequest)
    {
        return await _auth.Login(loginrequest);
    }
    
    [HttpGet("LoginTest")]
    public async Task<LoginResponseDTO?> LoginTest()
    {
        return await _auth.LoginTest();
    }
    
    [HttpPost("Register")]
    public async Task<bool> Register(UserDTO registerrequest)
    {
        return await _auth.Register(registerrequest);
    }
    
    [HttpGet("GetUser/{id}")]
    public async Task<User> GetUserInfo(string id)
    {
        return await _auth.GetUser(id);
    }

    [HttpPost("CheckToken")]
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