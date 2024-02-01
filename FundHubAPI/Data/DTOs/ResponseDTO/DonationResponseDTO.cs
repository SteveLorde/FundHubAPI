namespace FundHubAPI.Data.DTOs.ResponseDTO;

public class DonationResponseDTO
{
    public Guid UserId { get; set; }
    public Guid ProjectId { get; set; }
    public DateOnly Date { get; set; }
    public decimal DonationAmount { get; set; }
    public bool Status { get; set; }
}