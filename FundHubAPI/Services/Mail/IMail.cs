using FundHubAPI.Data.Models;

namespace FundHubAPI.Services.Mail;

public interface IMail
{
    public Task<bool> SendMail(MailRequest mailRequest);
}