using FundHubAPI.Data.Models;
using FundHubAPI.Services.JWT.DTO;

namespace FundHubAPI.Services.JWT;

public interface IJWT
{
    public string CreateToken(JWTRequestDTO jwtrequest);
}