using FundHubAPI.Data.Models;

namespace FundHubAPI.Data.DTOs;

public interface ProjectDTO : TDTO
{
    public string title { get; set; }
    public string? subtitle { get; set; }
    public string description { get; set; }
    public string? category { get; set; }
    public Guid? UserId { get; set; }
    public User? User { get; set; }
    public int currentfund { get; set; }
    public int totalfundrequired { get; set; }
    public string[] images { get; set; }
    public IFormFile[]? imagefiles { get; set; }
}