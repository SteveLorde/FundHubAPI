using FundHub.Data.Data.Models;

namespace FundHub.Services.Services.Mail;

public interface IMail
{
    public Task<bool> SendMail(MailRequest mailRequest);
}