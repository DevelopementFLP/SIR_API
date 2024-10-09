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
    public class FtTipoDeEnvaseController : ControllerBase
    {
        private readonly IFtTipoDeEnvase _FtTipoDeEnvaseServicio;

        // Constructor del servicio
        public FtTipoDeEnvaseController(IFtTipoDeEnvase ftTipoDeEnvaseServicio)
        {
            _FtTipoDeEnvaseServicio = ftTipoDeEnvaseServicio;
        }

        [HttpGet("ListaTipoDeEnvaseFichaTecnica")]
        public async Task<IActionResult> Lista()
        {
            var response = new ResponseDto<List<TipoDeEnvaseDTO>>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _FtTipoDeEnvaseServicio.Lista();
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("CrearTipoDeEnvaseFichaTecnica")]
        public async Task<IActionResult> Crear([FromBody] TipoDeEnvaseDTO modelo)
        {
            var response = new ResponseDto<TipoDeEnvaseDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _FtTipoDeEnvaseServicio.Crear(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("EditarTipoDeEnvaseFichaTecnica")]
        public async Task<IActionResult> Editar([FromBody] TipoDeEnvaseDTO modelo)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = await _FtTipoDeEnvaseServicio.Editar(modelo);
                response.Mensaje = response.EsCorrecto ? "Tipo de envase editado con éxito." : "No se pudo editar el tipo de envase.";
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete("EliminarTipoDeEnvaseFichaTecnica/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = await _FtTipoDeEnvaseServicio.Eliminar(id);
                response.Mensaje = response.EsCorrecto ? "Tipo de envase eliminado con éxito." : "No se pudo eliminar el tipo de envase.";
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
