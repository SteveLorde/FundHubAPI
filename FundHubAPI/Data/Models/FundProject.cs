namespace FundHubAPI.Data.Models;

public class FundProject
{
    
    public Guid Id { get; set; }
    public string title { get; set; }
    public string? subtitle { get; set; }
    public string description { get; set; }
    public string? category { get; set; }
    public Guid UserId { get; set; }
}