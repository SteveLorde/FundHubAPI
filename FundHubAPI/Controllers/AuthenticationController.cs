using API.Services.Authentication;
using API.Services.JWT;
using FundHubAPI.Data.DTOs;
using FundHubAPI.Data.Models;
using FundHubAPI.Services.JWT;
using Microsoft.AspNetCore.Authorization;
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
    public async Task<string?> Login(UserDTO loginrequest)
    {
        return await _auth.Login(loginrequest);
    }
    
    [HttpGet("LoginTest")]
    public async Task<string?> LoginTest()
    {
        return await _auth.LoginTest();
    }
    
    [HttpPost("Register")]
    public async Task<bool> Register(UserDTO registerrequest)
    {
        return await _auth.Register(registerrequest);
    }
    
    [Authorize]
    [HttpGet("GetUser")]
    public async Task<User> GetUserInfo()
    {
        string userid = HttpContext.User.FindFirst("userid").Value;
        return await _auth.GetUser(userid);
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