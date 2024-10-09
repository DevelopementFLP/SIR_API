using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaIntegralReportes.DTO.FichaTecnica;
using SistemaIntegralReportes.DTO;
using SistemaIntegralReportes.Servicios.Contrato.FichaTecnica;
using SistemaIntegralreportes.DTO;

namespace SistemaIntegralReportes.Controllers.FichaTecnica
{
    [Route("api/[controller]")]
    [ApiController]
    public class FtVidaUtilController : ControllerBase
    {
        private readonly IFtVidaUtil _FtVidaUtilServicio;

        // Constructor del servicio
        public FtVidaUtilController(IFtVidaUtil ftVidaUtilServicio)
        {
            _FtVidaUtilServicio = ftVidaUtilServicio;
        }

        [HttpGet("ListaVidaUtilFichaTecnica")]
        public async Task<IActionResult> Lista()
        {
            var response = new ResponseDto<List<VidaUtilDTO>>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _FtVidaUtilServicio.Lista();
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("CrearVidaUtilFichaTecnica")]
        public async Task<IActionResult> Crear([FromBody] VidaUtilDTO modelo)
        {
            var response = new ResponseDto<VidaUtilDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _FtVidaUtilServicio.Crear(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("EditarVidaUtilFichaTecnica")]
        public async Task<IActionResult> Editar([FromBody] VidaUtilDTO modelo)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = await _FtVidaUtilServicio.Editar(modelo);
                response.Mensaje = response.EsCorrecto ? "Vida útil editada con éxito." : "No se pudo editar la vida útil.";
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete("EliminarVidaUtilFichaTecnica/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = await _FtVidaUtilServicio.Eliminar(id);
                response.Mensaje = response.EsCorrecto ? "Vida útil eliminada con éxito." : "No se pudo eliminar la vida útil.";
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
