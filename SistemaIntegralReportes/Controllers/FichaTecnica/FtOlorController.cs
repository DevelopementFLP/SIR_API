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
    public class FtOlorController : ControllerBase
    {
        private readonly IFtOlor _FtOlorServicio;

        // Constructor del servicio
        public FtOlorController(IFtOlor ftOlorServicio)
        {
            _FtOlorServicio = ftOlorServicio;
        }

        [HttpGet("ListaOloresFichaTecnica")]
        public async Task<IActionResult> Lista()
        {
            var response = new ResponseDto<List<OlorDTO>>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _FtOlorServicio.Lista();
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("CrearOlorFichaTecnica")]
        public async Task<IActionResult> Crear([FromBody] OlorDTO modelo)
        {
            var response = new ResponseDto<OlorDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _FtOlorServicio.Crear(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("EditarOlorFichaTecnica")]
        public async Task<IActionResult> Editar([FromBody] OlorDTO modelo)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = await _FtOlorServicio.Editar(modelo);
                response.Mensaje = response.EsCorrecto ? "Olor editado con éxito." : "No se pudo editar el Olor.";
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete("EliminarOlorFichaTecnica/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = await _FtOlorServicio.Eliminar(id);
                response.Mensaje = response.EsCorrecto ? "Olor eliminado con éxito." : "No se pudo eliminar el Olor.";
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
