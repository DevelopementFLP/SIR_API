using SistemaIntegralReportes.DTO.ControlDeCalidad.Incidentes;

namespace SistemaIntegralReportes.Servicios.Contrato.ControlDeCalidad.Incidentes
{
    public interface ITrazabilidad
    {
        Task<List<TrazabilidadDTO>> BuscarTrazabilidad(int codigoQr);

    }
}
