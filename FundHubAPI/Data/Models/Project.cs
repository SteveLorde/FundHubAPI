using System.ComponentModel.DataAnnotations;

namespace FundHubAPI.Data.Models;

public class Project
{
    [Key]
    public Guid Id { get; set; }
    public string title { get; set; }
    public string? subtitle { get; set; }
    public string description { get; set; }
    public Guid CategoryId { get; set; }
    public Category category { get; set; }
    public Guid? UserId { get; set; }
    public User? User { get; set; }
    public int currentfund { get; set; }
    public int totalfundrequired { get; set; }
    public string[] images { get; set; }

}