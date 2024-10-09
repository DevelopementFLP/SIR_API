using SistemaIntegralReportes.DTO.Dispositivos;

namespace SistemaIntegralReportes.Servicios.Contrato.Dispositivos
{
    public interface ITipoDispositivo
    {
        Task<List<TipoDispositivoDTO>> Lista(string buscar);
        Task<TipoDispositivoDTO> Buscar(int id);
        Task<TipoDispositivoDTO> Crear(TipoDispositivoDTO modelo);
        Task<bool> Editar(TipoDispositivoDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
