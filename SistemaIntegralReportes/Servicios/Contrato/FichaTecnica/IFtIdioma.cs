using SistemaIntegralReportes.DTO.FichaTecnica;

namespace SistemaIntegralReportes.Servicios.Contrato.FichaTecnica
{
    public interface IFtIdioma
    {
        Task<List<IdiomaDTO>> Lista();
        Task<IdiomaDTO> Crear(IdiomaDTO modelo);
        Task<bool> Editar(IdiomaDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
