using FundHubAPI.Data.Models;

namespace FundHubAPI.Data.DTOs;

public interface AuthRequestDTO
{
    public User user { get; set; }
    public string token { get; set; }
}