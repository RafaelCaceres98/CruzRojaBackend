
using Backend_CruzRoja.Entidades;
// EmailService.cs
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Threading.Tasks;

public interface IEmailService
{
    Task SendEmailAsync(string to, string subject, string htmlMessage);
}

public class EmailService : IEmailService
{
    private readonly EmailSettings _emailSettings;

    public EmailService(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }

    public async Task SendEmailAsync(string to, string subject, string htmlMessage)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.SenderEmail));
        message.To.Add(new MailboxAddress("", to));
        message.Subject = subject;
        message.Body = new TextPart("html") { Text = htmlMessage };

        using var client = new SmtpClient();
        await client.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.SmtpPort, false);
        await client.AuthenticateAsync(_emailSettings.SenderEmail, _emailSettings.Password);
        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }
}

