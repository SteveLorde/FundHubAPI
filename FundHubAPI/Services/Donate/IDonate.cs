namespace FundHubAPI.Services.Donate;

public interface IDonate
{
    public Task Donate(string projectid, string userid);
    public Task CancelDonation(string donationid);
}