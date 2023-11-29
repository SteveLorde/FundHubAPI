using System.ComponentModel.DataAnnotations;

namespace FundHubAPI.Data.Models;

public class FundLogs
{
    [Key]
    public Guid Id { get; set; }
    public Guid FundProjectId { get; set; }
    public FundProject? Product { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public bool accepted { get; set; }
    public DateTime datetime { get; set; }
}