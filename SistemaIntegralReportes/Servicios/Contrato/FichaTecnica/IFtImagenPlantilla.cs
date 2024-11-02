using SistemaIntegralReportes.DTO.FichaTecnica.CrearPlantillas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaIntegralReportes.Servicios.Contrato.FichaTecnica
{
    public interface IFtImagenPlantilla
    {
        Task<ImagenesPlantillaDTO> Crear(string codigoDeProducto, int seccionDeImagen, byte[] imagenBytes); // Modificado
        Task<bool> Editar(ImagenesPlantillaDTO modelo, byte[] imagenBytes); // Modificado para aceptar imagen
        Task<bool> Eliminar(int id);
        Task<List<ImagenesPlantillaDTO>> BuscarImagenPorProducto(string codigoDeProducto);

    }
}
