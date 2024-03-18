using FundHubAPI.Data.DTOs;
using FundHubAPI.Data.DTOs.RequestDTO;
using FundHubAPI.Services.Authentication;
using FundHubAPI.Services.JWT;
using FundHubAPI.Services.Repositories.UsersRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FundHubAPI.Controllers;

[ApiController]
[Route("Authentication")]
public class AuthenticationController : Controller
{
    private readonly IAuthentication _auth;
    private readonly IJWT _jwt;
    private readonly IUserRepository _userepo;

    public AuthenticationController(IAuthentication auth, IUserRepository userrepo ,IJWT jwt)
    {
        _auth = auth;
        _jwt = jwt;
        _userepo = userrepo;
    }

    [HttpPost("Login")]
    public async Task<string?> Login(LoginRequestDTO loginrequest)
    {
        return await _auth.Login(loginrequest);
    }

    [HttpPost("Register")]
    public async Task<bool> Register(RegisterRequestDTO registerrequest)
    {
        return await _auth.Register(registerrequest);
    }
    
    [Authorize]
    [HttpGet("GetLoggedUser")]
    public async Task<UserDTO> GetUserInfo()
    {
        string userid = HttpContext.User.FindFirst("userid").Value;
        return await _userepo.GetUser(userid);
    }
    
}