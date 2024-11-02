
using Microsoft.AspNetCore.Mvc;
using SistemaIntegralReportes.DTO.FichaTecnica;
using SistemaIntegralReportes.Servicios.Contrato.FichaTecnica;
using SistemaIntegralreportes.DTO;

namespace SistemaIntegralReportes.Controllers.FichaTecnica
{
    [Route("api/[controller]")]
    [ApiController]
    public class FtProductosController : ControllerBase
    {
        private readonly IFtProductos _ftProductosServicio;

        // Constructor del servicio
        public FtProductosController(IFtProductos ftProductosServicio)
        {
            _ftProductosServicio = ftProductosServicio;
        }

        [HttpGet("BuscarProductoFichaTecnica")]
        public async Task<IActionResult> BuscarProducto(string codigoProducto)
        {
            var response = new ResponseDto<ProductoFichaTecnicaDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _ftProductosServicio.BuscarProducto(codigoProducto);
                if (response.Resultado == null)
                {
                    response.EsCorrecto = false;
                    response.Mensaje = "Producto no encontrado.";
                }
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("EditarProductoFichaTecnica")]
        public async Task<IActionResult> Editar([FromBody] ProductoFichaTecnicaDTO modelo)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = await _ftProductosServicio.Editar(modelo);
                response.Mensaje = response.EsCorrecto ? "Producto editado con éxito." : "No se pudo editar el Producto.";
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
