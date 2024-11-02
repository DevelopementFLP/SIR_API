using SistemaIntegralReportes.DTO.FichaTecnica.CrearPlantillas;

namespace SistemaIntegralReportes.Servicios.Contrato.FichaTecnica
{
    public interface IFtEspecificacionesPlantilla
    {
        Task<List<EspecificacionesPlantillaDTO>> ListaDeEspecificaciones();
        Task<EspecificacionesPlantillaDTO> Crear(EspecificacionesPlantillaDTO modelo);        
        Task<bool> Editar(EspecificacionesPlantillaDTO modelo);
        Task<EspecificacionesPlantillaDTO> BuscarPlantillaEspecificaciones(string descripcionDePlantilla);
    }
}
