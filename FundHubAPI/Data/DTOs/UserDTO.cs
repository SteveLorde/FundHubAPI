namespace FundHubAPI.Data.DTOs;

public class UserDTO
{
    public Guid Id { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public int? phonenumber { get; set; }
    public string email { get; set; }
    public string? facebook { get; set; }
    public string? x_socialmedia { get; set; }
    public string? instagram { get; set; }
    public string? profileimage { get; set; }
}