using FundHub.Services.Services.JWT.DTO;

namespace FundHub.Services.Services.JWT;

public interface IJWT
{
    public string CreateToken(JWTRequestDTO jwtrequest);
}