using FundHub.Data.Data.DTOs.RequestDTO;

namespace FundHub.Services.Services.Authentication;

public interface IAuthentication
{
    public Task<string> Login(LoginRequestDTO loginreq);
    public Task<bool> Register(RegisterRequestDTO registerreq);
}