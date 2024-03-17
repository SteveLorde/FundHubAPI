using FundHubAPI.Data.Models;

namespace FundHubAPI.Services.Mail;

public interface IMail
{
    public Task SendMail(MailRequest mailRequest);
}