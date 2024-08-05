using SistemaIntegralreportes.DTO;

namespace SistemaIntegralReportes.Servicios.Contrato
{
    public interface IUbicacionesDispositivo
    {
        Task<List<UbicacionesDispositivosDTO>> Lista(string buscar);
        Task<UbicacionesDispositivosDTO> Buscar(int id);
        Task<UbicacionesDispositivosDTO> Crear(UbicacionesDispositivosDTO modelo);
        Task<bool> Editar(UbicacionesDispositivosDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
