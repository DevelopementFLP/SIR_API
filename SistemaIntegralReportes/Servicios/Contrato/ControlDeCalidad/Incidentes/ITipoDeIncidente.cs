using SistemaIntegralReportes.DTO.ControlDeCalidad.Incidentes;
using SistemaIntegralReportes.DTO.FichaTecnica;

namespace SistemaIntegralReportes.Servicios.Contrato.ControlDeCalidad.Incidentes
{
    public interface ITipoDeIncidente
    {
        Task<List<TipoDeIncidenteDTO>> ListaDeTipoDeIncidente();       
    }
}
