using SistemaIntegralReportes.DTO.FichaTecnica;

namespace SistemaIntegralReportes.Servicios.Contrato.FichaTecnica
{
    public interface IFtPresentacionDeEnvase
    {
        Task<List<PresentacionDeEnvaseDTO>> Lista();
        Task<PresentacionDeEnvaseDTO> Crear(PresentacionDeEnvaseDTO modelo);
        Task<bool> Editar(PresentacionDeEnvaseDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
