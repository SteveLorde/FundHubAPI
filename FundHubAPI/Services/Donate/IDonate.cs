using FundHubAPI.Data.DTOs;

namespace FundHubAPI.Services.Donate;

public interface IDonate
{
    public Task DonateToProject(DonationDTO donationtolog);
}