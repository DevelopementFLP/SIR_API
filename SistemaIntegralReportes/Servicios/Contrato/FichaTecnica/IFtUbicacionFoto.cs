using SistemaIntegralReportes.DTO.FichaTecnica;

namespace SistemaIntegralReportes.Servicios.Contrato.FichaTecnica
{
    public interface IFtUbicacionFoto
    {
        Task<List<UbicacionDeFotoDTO>> Lista();
        Task<UbicacionDeFotoDTO> Crear(UbicacionDeFotoDTO modelo);
        Task<bool> Editar(UbicacionDeFotoDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
