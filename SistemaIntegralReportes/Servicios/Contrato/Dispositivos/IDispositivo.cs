using SistemaIntegralReportes.DTO.Dispositivos;
using SistemaIntegralReportes.Models.Dispositivos;
using System.Linq.Expressions;

namespace SistemaIntegralReportes.Servicios.Contrato.Dispositivos
{
    public interface IDispositivo
    {
        Task<List<DispositivosDTO>> Lista(string buscar);
        Task<DispositivosDTO> Buscar(int id);
        Task<DispositivosDTO> Crear(DispositivosDTO modelo);
        Task<bool> Editar(DispositivosDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
