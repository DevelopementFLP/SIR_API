using SistemaIntegralReportes.DTO.FichaTecnica;

namespace SistemaIntegralReportes.Servicios.Contrato.FichaTecnica
{
    public interface IFtTipoDeEnvase
    {
        Task<List<TipoDeEnvaseDTO>> Lista();
        Task<TipoDeEnvaseDTO> Crear(TipoDeEnvaseDTO modelo);
        Task<bool> Editar(TipoDeEnvaseDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
