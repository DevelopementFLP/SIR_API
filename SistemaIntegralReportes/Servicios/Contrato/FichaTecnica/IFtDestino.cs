using SistemaIntegralReportes.DTO.FichaTecnica;

namespace SistemaIntegralReportes.Servicios.Contrato.FichaTecnica
{
    public interface IFtDestino
    {
        Task<List<DestinoDTO>> Lista();
        Task<DestinoDTO> Crear(DestinoDTO modelo);
        Task<bool> Editar(DestinoDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
