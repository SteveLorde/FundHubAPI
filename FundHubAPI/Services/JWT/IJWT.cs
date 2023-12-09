using FundHubAPI.Data.Models;

namespace FundHubAPI.Services.JWT;

public interface IJWT
{
    public string CreateToken(User user);
    public bool VerifyToken(string token);
}