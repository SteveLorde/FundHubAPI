namespace FundHubAPI.Data.DTOs.RequestDTO;

public interface DonationRequestDTO
{
    public Guid UserId { get; set; }
    public Guid ProjectId { get; set; }
    public DateOnly Date { get; set; }
    public decimal DonationAmount { get; set; }
}