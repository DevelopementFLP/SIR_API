using System.Net;
using System.Net.Mail;
using SistemaIntegralReportes.Models;

namespace SistemaIntegralReportes.Interfaces
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration) => _configuration = configuration;

        public void SendEmail(Email email)
        {
            string smtpServer = _configuration.GetSection("Email:Host").Value;
            int stmpPort = Convert.ToInt32(_configuration.GetSection("Email:Port").Value);
            string username = _configuration.GetSection("Email:UserName").Value;
            string password = _configuration.GetSection("Email:Password").Value;

            SmtpClient client = new SmtpClient(smtpServer, stmpPort);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(username, password);
            client.EnableSsl = Convert.ToBoolean(_configuration.GetSection("Email_SSL").Value);

            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(username);
                foreach(var dest in email.Para) mailMessage.To.Add(dest);
                mailMessage.IsBodyHtml = true;
                mailMessage.Subject = email.Asunto;
                mailMessage.Body = email.Contenido;

                client.Send(mailMessage);
                Console.WriteLine("Correo enviado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
