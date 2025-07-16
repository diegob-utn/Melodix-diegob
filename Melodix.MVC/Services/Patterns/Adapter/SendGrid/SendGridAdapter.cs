using Melodix.MVC.Services.Patterns.Adapter.SendGrid;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

public class SendGridAdapter:IMailProvider, IEmailSender
{
    private readonly string _apiKey;
    private readonly string _fromEmail;
    private readonly string _fromName;

    public SendGridAdapter(IConfiguration configuration)
    {
        _apiKey = configuration["SendGrid:ApiKey"] ?? Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
        _fromEmail = configuration["SendGrid:FromEmail"] ?? "no-reply@tudominio.com";
        _fromName = configuration["SendGrid:FromName"] ?? "Melodix";
    }

    // Para tu lógica interna
    public async Task SendEmailAsync(string to, string subject, string htmlMessage)
    {
        var client = new SendGridClient(_apiKey);
        var from = new EmailAddress(_fromEmail, _fromName);
        var toEmail = new EmailAddress(to);
        var msg = MailHelper.CreateSingleEmail(from, toEmail, subject, plainTextContent: null, htmlContent: htmlMessage);

        await client.SendEmailAsync(msg);
    }

    // Para Identity
    async Task IEmailSender.SendEmailAsync(string email, string subject, string htmlMessage)
    {

        await SendEmailAsync(email, subject, htmlMessage);
    }
}
