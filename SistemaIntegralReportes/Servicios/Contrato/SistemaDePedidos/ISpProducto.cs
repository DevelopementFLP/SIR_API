using SistemaIntegralReportes.AplicacionDePedidos.Entidades;

namespace SistemaIntegralReportes.Servicios.Contrato.SistemaDePedidos
{
    public interface ISpProducto
    {
        Task<List<Producto>> ListaDeProductos();
        Task<Producto> Crear(Producto modelo);
        Task<bool> Editar(Producto modelo);
        Task<Producto> BuscarProductoPorCodigo(string codigoDeProducto);

    }
}
