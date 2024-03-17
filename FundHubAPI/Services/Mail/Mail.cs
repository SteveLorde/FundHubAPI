using FundHubAPI.Data.Models;
using MailKit.Net.Smtp;
using MimeKit;

namespace FundHubAPI.Services.Mail;

class Mail : IMail
{
    public async Task SendMail(MailRequest mailRequest) 
    {
        var emailmessage = new MimeMessage();
        
        emailmessage.From.Add(new MailboxAddress("Mostafa Maher", "mostafa.maher98@gmail.com"));
        emailmessage.To.Add(new MailboxAddress("", mailRequest.Emailto));
        emailmessage.Subject = mailRequest.Subject;
        emailmessage.Body = new TextPart("plain")
        {
            Text = mailRequest.Message
        };

        var client = new SmtpClient();
        await client.ConnectAsync("", 587, false);
        await client.AuthenticateAsync("", "");
        await client.SendAsync(emailmessage);
        await client.DisconnectAsync(true);
    }
    
    
}