using FundHubAPI.Data.Models;
using MailKit.Net.Smtp;
using MimeKit;

namespace FundHubAPI.Services.Mail;

class Mail : IMail
{
    private readonly IConfiguration _config;
    private IConfigurationSection _emailsettings;

    public Mail(IConfiguration config)
    {
        _config = config;
        _emailsettings =_config.GetSection("EmailSettings");
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

        var client = new SmtpClient();
        await client.ConnectAsync(_emailsettings["SmtpServer"], Int16.Parse(_emailsettings["Port"]), bool.Parse(_emailsettings["IsSSL"]));
        await client.AuthenticateAsync(_emailsettings["Username"], _emailsettings["Password"]);
        bool check = client.SendAsync(emailmessage).IsCompletedSuccessfully;
        if (check)
        {
            await client.DisconnectAsync(true);
            return true;
        }
        else
        {
            return false;
        }
        

    }
    
    
}