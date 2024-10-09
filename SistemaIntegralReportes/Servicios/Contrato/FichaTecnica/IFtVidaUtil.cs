using SistemaIntegralReportes.DTO.FichaTecnica;

namespace SistemaIntegralReportes.Servicios.Contrato.FichaTecnica
{
    public interface IFtVidaUtil
    {
        Task<List<VidaUtilDTO>> Lista();
        Task<VidaUtilDTO> Crear(VidaUtilDTO modelo);
        Task<bool> Editar(VidaUtilDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
