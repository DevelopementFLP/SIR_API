using SistemaIntegralReportes.AplicacionDePedidos.Entidades;

namespace SistemaIntegralReportes.Servicios.Contrato.SistemaDePedidos
{
    public interface ISpCentroDeCosto
    {
        Task<List<CentroDeCosto>> ListaDeCentroDeCostos();
        Task<CentroDeCosto> Crear(CentroDeCosto modelo);
        Task<bool> Editar(CentroDeCosto modelo);
        Task<CentroDeCosto> BuscarCentroDeCostoPorCodigo(int codigo);
    }
}
