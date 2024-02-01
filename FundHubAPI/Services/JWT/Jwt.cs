using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FundHubAPI.Data.Models;
using Microsoft.IdentityModel.Tokens;

namespace FundHubAPI.Services.JWT;

class Jwt : IJWT
{
    private IConfiguration _config;

    private string jwtseckey;

    public Jwt(IConfiguration config)
    {
        _config = config;
        jwtseckey = _config["secretkey"];
    }

    public string CreateToken(User user)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.username),
            new Claim("userid", user.Id.ToString()),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtseckey));

        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var tokendata = new JwtSecurityToken(
            claims: claims,
            issuer: "http://localhost:5116",
            audience: "http://localhost:4200",
            expires: DateTime.Now.AddDays(1),
            signingCredentials: cred
        );
        var jwt = new JwtSecurityTokenHandler().WriteToken(tokendata);
        return jwt;
    }

    public bool VerifyToken(string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretkey = Encoding.UTF8.GetBytes(jwtseckey);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretkey),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero // You may adjust the clock skew as needed
            };

            ClaimsPrincipal principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);

            return true;

        }
        catch (Exception err)
        {
            throw err;
        }



    }
    
}