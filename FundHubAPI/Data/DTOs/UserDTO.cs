namespace FundHubAPI.Data.DTOs;

public interface UserDTO : TDTO
{
    public string username { get; set; }
    public string password { get; set; }
}