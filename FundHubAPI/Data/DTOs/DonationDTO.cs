namespace FundHubAPI.Data.DTOs;

public interface DonationDTO : TDTO
{
    public Guid userid { get; set; }
    public Guid projectid { get; set; }
    public DateOnly date { get; set; }
    public decimal donationamount { get; set; }
}