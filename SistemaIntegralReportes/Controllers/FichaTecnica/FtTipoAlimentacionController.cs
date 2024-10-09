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
    public class FtTipoAlimentacionController : ControllerBase
    {
        private readonly IFtTipoDeAlimentacion _FtTipoDeAlimentacionServicio;

        // Constructor del servicio
        public FtTipoAlimentacionController(IFtTipoDeAlimentacion ftTipoDeAlimentacionServicio)
        {
            _FtTipoDeAlimentacionServicio = ftTipoDeAlimentacionServicio;
        }

        [HttpGet("ListaAlimentacionFichaTecnica")]
        public async Task<IActionResult> Lista()
        {
            var response = new ResponseDto<List<TipoDeAlimentacionDTO>>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _FtTipoDeAlimentacionServicio.Lista();
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("CrearAlimentacionFichaTecnica")]
        public async Task<IActionResult> Crear([FromBody] TipoDeAlimentacionDTO modelo)
        {
            var response = new ResponseDto<TipoDeAlimentacionDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _FtTipoDeAlimentacionServicio.Crear(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("EditarAlimentacionFichaTecnica")]
        public async Task<IActionResult> Editar([FromBody] TipoDeAlimentacionDTO modelo)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = await _FtTipoDeAlimentacionServicio.Editar(modelo);
                response.Mensaje = response.EsCorrecto ? "Tipo de alimentación editado con éxito." : "No se pudo editar el tipo de alimentación.";
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete("EliminarAlimentacionFichaTecnica/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = await _FtTipoDeAlimentacionServicio.Eliminar(id);
                response.Mensaje = response.EsCorrecto ? "Tipo de alimentación eliminado con éxito." : "No se pudo eliminar el tipo de alimentación.";
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
