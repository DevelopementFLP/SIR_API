using SistemaIntegralReportes.DTO.FichaTecnica;
using SistemaIntegralReportes.DTO.FichaTecnica.CrearPlantillas;

namespace SistemaIntegralReportes.Servicios.Contrato.FichaTecnica
{
    public interface IFtAspectosGeneralesPlantilla
    {
        Task<List<AspectosGeneralesPlantillaDTO>> ListaDeAspectosGenerales();
        Task<AspectosGeneralesPlantillaDTO> Crear(AspectosGeneralesPlantillaDTO modelo);
        Task<bool> Editar(AspectosGeneralesPlantillaDTO modelo);
        Task<AspectosGeneralesPlantillaDTO> BuscarPlantillaAspectosGenerales(string descripcionDePlantilla);
    }
}
