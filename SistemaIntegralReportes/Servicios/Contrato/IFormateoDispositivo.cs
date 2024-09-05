using SistemaIntegralreportes.DTO;

namespace SistemaIntegralReportes.Servicios.Contrato
{
    public interface IFormateoDispositivo
    {
        Task<List<FormateosDTO>> Lista(string buscar);
        Task<FormateosDTO> Buscar(int id);
        Task<FormateosDTO> Crear(FormateosDTO modelo);
        Task<bool> Editar(FormateosDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
