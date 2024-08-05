using SistemaIntegralreportes.DTO;
using SistemaIntegralReportes.Models.Dispositivos;
using SistemaIntegralReportes.Models.Reportes;
using System.Linq.Expressions;

namespace SistemaIntegralReportes.Servicios.Contrato
{
    public interface IListaDeCajas
    {
        Task<List<ListaDeCajas>> BuscarListaDeLecturas(string id);
        Task<List<ListaDeCajas>> BuscarListaDeExportaciones(string id);
    }
}
