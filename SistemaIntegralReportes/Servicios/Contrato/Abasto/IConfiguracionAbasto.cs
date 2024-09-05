using SistemaIntegralReportes.DTO.Abasto;
using SistemaIntegralReportes.Models.Configuraciones;

namespace SistemaIntegralReportes.Servicios.Contrato.Abasto
{
    public interface IConfiguracionAbasto
    {
        Task<List<ParametrosDw_Abasto>> GetParametrosSeccionAbasto();
    }
}
