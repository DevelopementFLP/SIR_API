using SistemaIntegralReportes.DTO.Cajas;
using SistemaIntegralReportes.Models.Configuraciones;

namespace SistemaIntegralReportes.Servicios.Contrato.Cajas
{
    public interface IIdentificacionDeCajas
    {
        Task<IdentificadorDeCajasDTO> getLecturaDeCaja(string codigoDeCaja);
    }
}
