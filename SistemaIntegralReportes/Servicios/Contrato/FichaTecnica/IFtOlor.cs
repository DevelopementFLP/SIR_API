using SistemaIntegralReportes.DTO.FichaTecnica;

namespace SistemaIntegralReportes.Servicios.Contrato.FichaTecnica
{
    public interface IFtOlor
    {
        Task<List<OlorDTO>> Lista();
        Task<OlorDTO> Crear(OlorDTO modelo);
        Task<bool> Editar(OlorDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
