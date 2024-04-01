using FundHubAPI.Data.Models;

namespace FundHubAPI.Data.DTOs.ResponseDTO;

public class DonationResponseDTO
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public Project Project { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public decimal Donationamount { get; set; }
    public DateOnly Date { get; set; }
    public bool Status { get; set; }
}