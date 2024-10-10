using SistemaIntegralReportes.DTO.FichaTecnica;

namespace SistemaIntegralReportes.Servicios.Contrato.FichaTecnica
{
    public interface IFtPh
    {
        Task<List<PhDTO>> Lista();
        Task<PhDTO> Crear(PhDTO modelo);
        Task<bool> Editar(PhDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
