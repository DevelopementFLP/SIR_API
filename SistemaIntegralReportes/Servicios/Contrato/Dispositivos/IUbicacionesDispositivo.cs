using SistemaIntegralReportes.DTO.Dispositivos;

namespace SistemaIntegralReportes.Servicios.Contrato.Dispositivos
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
