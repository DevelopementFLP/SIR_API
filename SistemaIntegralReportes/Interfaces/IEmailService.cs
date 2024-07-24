using SistemaIntegralReportes.Models;

namespace SistemaIntegralReportes.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(Email email);
    }
}
