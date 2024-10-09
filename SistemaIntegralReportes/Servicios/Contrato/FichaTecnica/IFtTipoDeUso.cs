using SistemaIntegralReportes.DTO.FichaTecnica;

namespace SistemaIntegralReportes.Servicios.Contrato.FichaTecnica
{
    public interface IFtTipoDeUso
    {
        Task<List<TipoDeUsoDTO>> Lista();
        Task<TipoDeUsoDTO> Crear(TipoDeUsoDTO modelo);
        Task<bool> Editar(TipoDeUsoDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
