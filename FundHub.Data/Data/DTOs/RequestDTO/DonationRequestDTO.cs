namespace FundHub.Data.Data.DTOs.RequestDTO;

public record DonationRequestDTO
{
    public Guid Id { get; init;}
    public Guid UserId { get; init; }
    public Guid ProjectId { get; init; }
    public DateOnly Date { get; init; }
    public decimal DonationAmount { get; init; }
}