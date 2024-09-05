using SendGrid;
using SendGrid.Helpers.Mail;

namespace SistemaIntegralReportes.Servicios
{

    public interface IServicioEmail
    {
        Task Enviar();
    }

    public class EmailSendGridService: IServicioEmail
    {
        private readonly IConfiguration configuration;
        public EmailSendGridService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task Enviar()
        {
            var apiKey = configuration.GetValue<string>("SENDGRID_API_KEY");
            var email = configuration.GetValue<string>("SENDGRID_FROM");
            var nombre = configuration.GetValue<string>("SENDGRID_NOMBRE");

            var cliente = new SendGridClient(apiKey);
            var from = new EmailAddress(email, nombre);
            var subject = "Fulano de tal quiere tener acceso a SIR";
            var to = new EmailAddress(email, nombre);
            var mensajeTexto = "Hola! Este es contenido";
            var contenidoHtml = @"holahtml";
            var singleEmail = MailHelper.CreateSingleEmail(from, to, subject, mensajeTexto, contenidoHtml);
            var respuesta = await cliente.SendEmailAsync(singleEmail);
        }
    }
}
