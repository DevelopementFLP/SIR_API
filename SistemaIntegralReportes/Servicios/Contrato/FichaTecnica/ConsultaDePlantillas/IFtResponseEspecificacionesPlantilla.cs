
using SistemaIntegralReportes.DTO.FichaTecnica.ConsultaDePlantillas;
using SistemaIntegralReportes.DTO.FichaTecnica.Plantillas;

namespace SistemaIntegralReportes.Servicios.Contrato.FichaTecnica.ConsultaDePlantillas
{
    public interface IFtResponseEspecificacionesPlantilla
    {
        Task<List<ResponseEspecificacionesDTO>> ObtenerEspecificacionesPlantilla(int idPlantilla);
    }
}
