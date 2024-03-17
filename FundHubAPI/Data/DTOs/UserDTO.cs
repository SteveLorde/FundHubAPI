using FundHubAPI.Data.Models;

namespace FundHubAPI.Data.DTOs;

public class UserDTO
{

    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Pass_salt { get; set; }
    public string Hashedpassword { get; set; }
    public string Usertype { get; set; }
    public int Phonenumber { get; set; }
    public string Email { get; set; }
    public string Facebook { get; set; }
    public string X { get; set; }
    public string Instagram { get; set; }
    public string Profileimage { get; set; }
    public List<Project> Projects { get; set; }
    public List<Donation> Donations { get; set; }
}