using SistemaIntegralReportes.DTO.FichaTecnica;

namespace SistemaIntegralReportes.Servicios.Contrato.FichaTecnica
{
    public interface IFtTipoDeAlimentacion
    {
        Task<List<TipoDeAlimentacionDTO>> Lista();
        Task<TipoDeAlimentacionDTO> Crear(TipoDeAlimentacionDTO modelo);
        Task<bool> Editar(TipoDeAlimentacionDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
