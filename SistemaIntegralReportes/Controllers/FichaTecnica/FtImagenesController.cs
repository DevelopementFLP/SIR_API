using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaIntegralReportes.DTO.FichaTecnica.CrearPlantillas;
using SistemaIntegralReportes.DTO;
using SistemaIntegralReportes.Servicios.Contrato.FichaTecnica;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaIntegralreportes.DTO;
using System.IO;

namespace SistemaIntegralReportes.Controllers.FichaTecnica
{
    [Route("api/[controller]")]
    [ApiController]
    public class FtImagenesController : ControllerBase
    {
        private readonly IFtImagenPlantilla _ftImagenPlantilla;

        // Constructor del servicio
        public FtImagenesController(IFtImagenPlantilla ftImagenPlantilla)
        {
            _ftImagenPlantilla = ftImagenPlantilla;
        }

        [HttpGet("BuscarImagenesPorProducto")]
        public async Task<IActionResult> BuscarPorSeccion(string codigoDeProducto)
        {
            var response = new ResponseDto<List<ImagenesPlantillaDTO>>();

            try
            {
                response.Resultado = await _ftImagenPlantilla.BuscarImagenPorProducto(codigoDeProducto);

                response.EsCorrecto = response.Resultado != null && response.Resultado.Count > 0;
                response.Mensaje = response.EsCorrecto ? "Imágenes encontradas." : "No se encontraron imágenes.";
            }
            catch (Exception ex)
            {
                // Manejo de errores
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }



        [HttpPost("CrearImagenFichaTecnica")]
        public async Task<IActionResult> Crear([FromForm] string codigoDeProducto, [FromForm] int seccionDeImagen, [FromForm] IFormFile imagenFile)
        {
            var response = new ResponseDto<ImagenesPlantillaDTO>();

            try
            {
                byte[] imagenBytes = null;

                if (imagenFile != null && imagenFile.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await imagenFile.CopyToAsync(memoryStream);
                        imagenBytes = memoryStream.ToArray(); 
                    }
                }

                // Llama al método Crear pasando la sección de imagen y el arreglo de bytes de la imagen
                response.Resultado = await _ftImagenPlantilla.Crear(codigoDeProducto, seccionDeImagen, imagenBytes);
                response.EsCorrecto = true;
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }



        [HttpPut("EditarImagenFichaTecnica")]
        public async Task<IActionResult> Editar([FromBody] ImagenesPlantillaDTO modelo)
        {
            var response = new ResponseDto<bool>();

            try
            {
               // response.EsCorrecto = await _ftImagenPlantilla.Editar(modelo);
                response.Mensaje = response.EsCorrecto ? "Imagen editada con éxito." : "No se pudo editar la imagen.";
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete("EliminarImagenFichaTecnica")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = await _ftImagenPlantilla.Eliminar(id);
                response.Mensaje = response.EsCorrecto ? "Imagen eliminada con éxito." : "No se pudo eliminar la imagen.";
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

       
    }
}
