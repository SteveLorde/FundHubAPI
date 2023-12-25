using System.ComponentModel.DataAnnotations;

namespace FundHubAPI.Data.Models;

public class DonationLog
{
    [Key]
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public Project? Project { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public decimal donationamount { get; set; }
    public DateOnly datetime { get; set; }
}