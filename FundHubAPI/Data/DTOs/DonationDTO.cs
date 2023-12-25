namespace FundHubAPI.Data.DTOs;

public interface DonationDTO : TDTO
{
    public string userid { get; set; }
    public string projectid { get; set; }
    public DateOnly date { get; set; }
    public decimal donationamount { get; set; }
}