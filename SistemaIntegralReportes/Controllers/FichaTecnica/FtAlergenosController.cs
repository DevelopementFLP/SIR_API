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
    public class FtAlergenosController : ControllerBase
    {
        private readonly IFtAlergenos _FtAlergenosServicio;

        // Constructor del servicio
        public FtAlergenosController(IFtAlergenos ftAlergenosServicio)
        {
            _FtAlergenosServicio = ftAlergenosServicio;
        }

        [HttpGet("ListaAlergenosFichaTecnica")]
        public async Task<IActionResult> Lista()
        {
            var response = new ResponseDto<List<AlergenosDTO>>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _FtAlergenosServicio.Lista();
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("CrearAlergenoFichaTecnica")]
        public async Task<IActionResult> Crear([FromBody] AlergenosDTO modelo)
        {
            var response = new ResponseDto<AlergenosDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _FtAlergenosServicio.Crear(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("EditarAlergenoFichaTecnica")]
        public async Task<IActionResult> Editar([FromBody] AlergenosDTO modelo)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = await _FtAlergenosServicio.Editar(modelo);
                response.Mensaje = response.EsCorrecto ? "Alergeno editado con éxito." : "No se pudo editar el alérgeno.";
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete("EliminarAlergenoFichaTecnica/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = await _FtAlergenosServicio.Eliminar(id);
                response.Mensaje = response.EsCorrecto ? "Alergeno eliminado con éxito." : "No se pudo eliminar el alérgeno.";
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
