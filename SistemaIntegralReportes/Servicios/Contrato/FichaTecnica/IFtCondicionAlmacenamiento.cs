using SistemaIntegralReportes.DTO.FichaTecnica;

namespace SistemaIntegralReportes.Servicios.Contrato.FichaTecnica
{
    public interface IFtCondicionAlmacenamiento
    {
        Task<List<CondicionDeAlmacenamientoDTO>> Lista();
        Task<CondicionDeAlmacenamientoDTO> Crear(CondicionDeAlmacenamientoDTO modelo);
        Task<bool> Editar(CondicionDeAlmacenamientoDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
