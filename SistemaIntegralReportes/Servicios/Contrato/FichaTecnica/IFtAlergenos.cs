using SistemaIntegralReportes.DTO.FichaTecnica;

namespace SistemaIntegralReportes.Servicios.Contrato.FichaTecnica
{
    public interface IFtAlergenos
    {
        Task<List<AlergenosDTO>> Lista();
        Task<AlergenosDTO> Crear(AlergenosDTO modelo);
        Task<bool> Editar(AlergenosDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
