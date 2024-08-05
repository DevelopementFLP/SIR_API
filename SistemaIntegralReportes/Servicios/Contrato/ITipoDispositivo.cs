using SistemaIntegralreportes.DTO;

namespace SistemaIntegralReportes.Servicios.Contrato
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
