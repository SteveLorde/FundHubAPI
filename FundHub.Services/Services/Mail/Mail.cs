using FundHub.Data.Data.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace FundHub.Services.Services.Mail;

public class Mail : IMail
{
    private readonly IConfiguration _config;
    private IConfigurationSection _emailsettings;
    private SmtpClient _client;

    public Mail(IConfiguration config)
    {
        _config = config;
        _emailsettings =_config.GetSection("EmailSettings");
        _client = new SmtpClient();
    }
    
    public async Task<bool> SendMail(MailRequest mailRequest)
    {
        var emailmessage = new MimeMessage();
        
        emailmessage.From.Add(new MailboxAddress(_emailsettings["SenderName"], _emailsettings["SenderEmail"]));
        emailmessage.To.Add(new MailboxAddress("", mailRequest.Emailto));
        emailmessage.Subject = mailRequest.Subject;
        emailmessage.Body = new TextPart("plain")
        {
            Text = mailRequest.Message
        };
        
        await _client.ConnectAsync(_emailsettings["SmtpServer"], Int16.Parse(_emailsettings["Port"]), bool.Parse(_emailsettings["IsSSL"]));
        await _client.AuthenticateAsync(_emailsettings["CompanyMail"], _emailsettings["CompanyPassword"]);
        bool check = _client.SendAsync(emailmessage).IsCompletedSuccessfully;
        if (check)
        {
            await _client.DisconnectAsync(true);
            return true;
        }
        else
        {
            return false;
        }
    }
    
    
}