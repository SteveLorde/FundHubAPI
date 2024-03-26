using FundHubAPI.Data.DTOs;
using FundHubAPI.Data.DTOs.RequestDTO;
using FundHubAPI.Data.DTOs.ResponseDTO;
using FundHubAPI.Data.Models;

namespace FundHubAPI.Services.Donate;

public interface IDonate
{
    public Task<List<DonationResponseDTO>> GetDonations();
    public Task<bool> DecideDonation(string donationid, bool decision);
    public Task<bool> DonateToProject(DonationRequestDTO donationtolog);
}