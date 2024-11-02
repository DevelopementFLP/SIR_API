
using SistemaIntegralReportes.DTO.FichaTecnica.CrearPlantillas;
using SistemaIntegralReportes.DTO.FichaTecnica.Plantillas;

namespace SistemaIntegralReportes.Servicios.Contrato.FichaTecnica.ConsultaDePlantillas
{
    public interface IFtResponseAspectosGeneralesPlantilla
    {
        Task<List<ResponseAspectosGeneralesDTO>> ObtenerAspectosGeneralesPlantilla(int idPlantilla);
    }
}
