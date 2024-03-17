using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FundHubAPI.Data.Models;
using FundHubAPI.Services.JWT.DTO;
using Microsoft.IdentityModel.Tokens;

namespace FundHubAPI.Services.JWT;

class Jwt : IJWT
{
    private IConfiguration _config;
    private string apihost;
    private string jwtseckey;
    private string audienceUrl;
    private readonly IHttpContextAccessor _httpcontext;

    public Jwt(IConfiguration config, IHttpContextAccessor httpcontext)
    {
        _config = config;
        jwtseckey = _config["secretkey"];
        audienceUrl = _config["audienceUrl"];
        _httpcontext = httpcontext;
    }

    public string CreateToken(JWTRequestDTO jwtrequest)
    {
        
        string baseUrl = $"{_httpcontext.HttpContext.Request.Scheme}://{_httpcontext.HttpContext.Request.Host}{_httpcontext.HttpContext.Request.PathBase}";
        
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, jwtrequest.username),
            new Claim("userid", jwtrequest.Id.ToString()),
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtseckey));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
        var tokendata = new JwtSecurityToken(
            claims: claims,
            issuer: baseUrl,
            audience: audienceUrl,
            expires: DateTime.Now.AddDays(2),
            signingCredentials: cred
        );
        var jwt = new JwtSecurityTokenHandler().WriteToken(tokendata);
        return jwt;
    }
    
}