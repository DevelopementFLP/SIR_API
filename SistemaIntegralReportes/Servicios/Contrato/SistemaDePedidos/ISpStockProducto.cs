using SistemaIntegralReportes.AplicacionDePedidos.Entidades;

namespace SistemaIntegralReportes.Servicios.Contrato.SistemaDePedidos
{
    public interface ISpStockProducto
    {
        Task<List<StockProducto>> ListaDeStockProductos();
        Task<StockProducto> Crear(StockProducto modelo);
        Task<bool> Editar(StockProducto modelo);
        Task<StockProducto> BuscarStockProducto(int idAlmacen, int idProducto, int idEmpresa);
    }
}
