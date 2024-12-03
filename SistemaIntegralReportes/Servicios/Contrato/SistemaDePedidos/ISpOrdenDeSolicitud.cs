using SistemaIntegralReportes.AplicacionDePedidos.Entidades;

namespace SistemaIntegralReportes.Servicios.Contrato.SistemaDePedidos
{
    public interface ISpOrdenDeSolicitud
    {
        Task<List<OrdenDeSolicitud>> ListaDeOrdenes();

        Task<OrdenDeSolicitud> Crear(OrdenDeSolicitud modelo);

        Task<bool> Editar(OrdenDeSolicitud modelo);

        Task<OrdenDeSolicitud> BuscarOrden(string nombre);

    }
}
