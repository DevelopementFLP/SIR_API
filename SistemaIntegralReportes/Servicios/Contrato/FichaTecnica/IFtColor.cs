using SistemaIntegralReportes.DTO.FichaTecnica;

namespace SistemaIntegralReportes.Servicios.Contrato.FichaTecnica
{
    public interface IFtColor
    {
        Task<List<ColorDTO>> Lista();
        Task<ColorDTO> Crear(ColorDTO modelo);
        Task<bool> Editar(ColorDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
