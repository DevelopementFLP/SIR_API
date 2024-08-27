using SistemaIntegralReportes.DTO.Abasto;
using SistemaIntegralReportes.Models.Reportes.ReporteAbasto;

namespace SistemaIntegralReportes.Servicios.Contrato.Abasto
{
    public interface ILecturaDeAbasto
    {
        Task<List<LecturaDeAbastoDTO>> GetLecturaDeAbasto();

        Task<LecturaDeAbastoDTO> InsertarLectura(string lectura, string operacion, DateTime? fechaDeFaena, decimal? peso);

        Task<List<ListaDeLecturasAbasto>> ListarLecturasVistaAbasto(DateTime fechaDelDia);
    }
}
