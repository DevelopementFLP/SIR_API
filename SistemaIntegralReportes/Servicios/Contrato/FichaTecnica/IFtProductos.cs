using SistemaIntegralReportes.DTO.FichaTecnica;

namespace SistemaIntegralReportes.Servicios.Contrato.FichaTecnica
{
    public interface IFtProductos
    {
        Task<ProductoFichaTecnicaDTO> BuscarProducto(string codigoProducto);

        Task<ProductoFichaTecnicaDTO> CrearProducto(ProductoFichaTecnicaDTO modelo);
        Task<bool> Editar(ProductoFichaTecnicaDTO modelo);
    }
}
