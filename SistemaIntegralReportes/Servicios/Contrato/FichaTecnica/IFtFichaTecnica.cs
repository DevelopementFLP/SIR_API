using SistemaIntegralReportes.DTO.FichaTecnica;

namespace SistemaIntegralReportes.Servicios.Contrato.FichaTecnica
{
    public interface IFtFichaTecnica
    {
        Task<List<FichaTecnicaDTO>> Buscar(string codigoDeProducto);
        Task<FichaTecnicaDTO> Crear(FichaTecnicaDTO modelo);
        Task<bool> Editar(FichaTecnicaDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
