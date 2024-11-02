
using Microsoft.AspNetCore.Mvc;
using SistemaIntegralReportes.Servicios.Contrato.FichaTecnica; 
using SistemaIntegralreportes.DTO;
using SistemaIntegralReportes.DTO.FichaTecnica;

namespace SistemaIntegralReportes.Controllers.FichaTecnica
{
    [Route("api/[controller]")]
    [ApiController]
    public class FtDestinoController : ControllerBase
    {
        private readonly IFtDestino _FtDestinoServicio; 

        public FtDestinoController(IFtDestino ftDestinoServicio)
        {
            _FtDestinoServicio = ftDestinoServicio;
        }

        [HttpGet("ListaDestinosFichaTecnica")]
        public async Task<IActionResult> Lista()
        {
            var response = new ResponseDto<List<DestinoDTO>>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _FtDestinoServicio.Lista(); 
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("CrearDestinoFichaTecnica")]
        public async Task<IActionResult> Crear([FromBody] DestinoDTO modelo)
        {
            var response = new ResponseDto<DestinoDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _FtDestinoServicio.Crear(modelo); 
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("EditarDestinoFichaTecnica")]
        public async Task<IActionResult> Editar([FromBody] DestinoDTO modelo)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = await _FtDestinoServicio.Editar(modelo); 
                response.Mensaje = response.EsCorrecto ? "Destino editado con éxito." : "No se pudo editar el destino.";
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete("EliminarDestinoFichaTecnica")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = await _FtDestinoServicio.Eliminar(id); 
                response.Mensaje = response.EsCorrecto ? "Destino eliminado con éxito." : "No se pudo eliminar el destino.";
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
