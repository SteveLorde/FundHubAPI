using FundHub.Data.Data.DTOs.RequestDTO;
using FundHub.Data.Data.DTOs.ResponseDTO;
using FundHub.Services.Services.Donate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FundHubAPI.Controllers;

[ApiController]
[Route("donations")]
public class DonationsController : Controller
{
    private readonly IDonate _donationservice;

    public DonationsController(IDonate donationservice)
    {
        _donationservice = donationservice;
    }

    [HttpGet("getdonations")]
    public async Task<List<DonationResponseDTO>> GetDonations()
    {
        return await _donationservice.GetDonations();
    }

    [Authorize]
    [HttpPost("decidedonation")]
    public async Task<bool> DecideDonation(string donationid, bool decision)
    {
        return await _donationservice.DecideDonation(donationid, decision);
    }

    [Authorize]
    [HttpPost]
    public async Task<bool> Donate(DonationRequestDTO donationrequest)
    {
        return await _donationservice.DonateToProject(donationrequest);
    }
    
}