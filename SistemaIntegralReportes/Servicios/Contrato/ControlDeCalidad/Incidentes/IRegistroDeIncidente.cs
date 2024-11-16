using SistemaIntegralReportes.DTO.ControlDeCalidad.Incidentes;
using SistemaIntegralReportes.DTO.FichaTecnica.CrearPlantillas;

namespace SistemaIntegralReportes.Servicios.Contrato.ControlDeCalidad.Incidentes
{
    public interface IRegistroDeIncidente
    {
        Task<RegistroDeIncidenteDTO> Crear(string codigoQr, string PuestoDeTrabajo, string Empleado, string Producto, string Hora, int IdTipoDeIncidente, byte[] imagenBytes);

        Task<List<IncidentesDTO>> ListaDeIncidentes( string fechaDelDia);
    }
}
