using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundHubAPI.Data.Models;



public class User
{
    [Key]
    public Guid UserId { get; set; }
    public string username { get; set; }
    [NotMapped]
    public string? password { get; set; }
    public string? pass_salt { get; set; }
    public string? hashedpassword { get; set; }
    public string usertype { get; set; }
    public int? phonenumber { get; set; }
    public string? email { get; set; }

}