using SistemaIntegralReportes.DTO.FichaTecnica;

namespace SistemaIntegralReportes.Servicios.Contrato.FichaTecnica
{
    public interface IFtMarcas
    {
        Task<List<MarcaDTO>> Lista();
        Task<MarcaDTO> Crear(MarcaDTO modelo);
        Task<bool> Editar(MarcaDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
