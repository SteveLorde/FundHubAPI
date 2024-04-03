using FundHub.Data.Data.DTOs.RequestDTO;
using FundHub.Data.Data.DTOs.ResponseDTO;

namespace FundHub.Services.Services.Donate;

public interface IDonate
{
    public Task<List<DonationResponseDTO>> GetDonations();
    public Task<bool> DecideDonation(string donationid, bool decision);
    public Task<bool> DonateToProject(DonationRequestDTO donationtolog);
}