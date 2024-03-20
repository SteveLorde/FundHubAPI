using FundHubAPI.Data.DTOs.RequestDTO;
using FundHubAPI.Data.Models;
using FundHubAPI.Services.Donate;
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
    public async Task<List<Donation>> GetDonations()
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