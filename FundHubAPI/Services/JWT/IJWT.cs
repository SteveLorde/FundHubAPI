using FundHubAPI.Data.Models;


namespace API.Services.JWT;

public interface IJWT
{
    public string CreateToken(User user);
    public bool VerifyToken(string token);
}