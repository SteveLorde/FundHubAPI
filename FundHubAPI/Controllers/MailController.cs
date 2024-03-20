using FundHubAPI.Data.Models;
using FundHubAPI.Services.Mail;
using Microsoft.AspNetCore.Mvc;

namespace FundHubAPI.Controllers;

[ApiController]
[Route("Mail")]
public class MailController : Controller
{
    private readonly IMail _mailservice;

    public MailController(IMail mailservice)
    {
        _mailservice = mailservice;
    }
    
    [HttpGet("sendmail")]
    public async Task<bool> SendMail(MailRequest mailtosend)
    {
        return await _mailservice.SendMail(mailtosend);
    }
}