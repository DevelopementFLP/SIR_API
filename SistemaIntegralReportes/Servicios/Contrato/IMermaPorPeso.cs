using SistemaIntegralReportes.Models.Reportes;

namespace SistemaIntegralReportes.Servicios.Contrato
{
    public interface IMermaPorPeso
    {

        Task<List<MermaPorPeso>> BuscarListaDeMermasPorPeso(string fechaDesde, string fechaHast);

    }
}
