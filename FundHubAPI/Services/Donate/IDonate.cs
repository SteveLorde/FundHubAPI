using FundHubAPI.Data.DTOs;
using FundHubAPI.Data.DTOs.RequestDTO;

namespace FundHubAPI.Services.Donate;

public interface IDonate
{
    public Task DonateToProject(DonationRequestDTO donationtolog);
}