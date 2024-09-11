using SistemaIntegralReportes.DTO.Abasto;
using SistemaIntegralReportes.Models.Faena.Reportes;

namespace SistemaIntegralReportes.Servicios.Contrato.Faena
{
    public interface IReporteDeFaena
    {
        Task<List<ReporteDeMediasProductoDTO>> GetReportePorProducto(string fechaDesde, string fechaHasta);

        Task<List<ReporteDeMediasProveedorDTO>> GetReportePorProveedor(string fechaDesde, string fechaHasta);

        Task<List<ReporteDeMediasGradeDTO>> GetReportePorGrade(string fechaDesde, string fechaHasta);
    }
}
