
using Microsoft.AspNetCore.Mvc;
using SistemaIntegralReportes.DTO.FichaTecnica;
using SistemaIntegralReportes.Servicios.Contrato.FichaTecnica;
using SistemaIntegralreportes.DTO;

namespace SistemaIntegralReportes.Controllers.FichaTecnica
{
    [Route("api/[controller]")]
    [ApiController]
    public class FtPresentacionDeEnvaseController : ControllerBase
    {
        private readonly IFtPresentacionDeEnvase _FtPresentacionDeEnvaseServicio;

        // Constructor del servicio
        public FtPresentacionDeEnvaseController(IFtPresentacionDeEnvase ftPresentacionDeEnvaseServicio)
        {
            _FtPresentacionDeEnvaseServicio = ftPresentacionDeEnvaseServicio;
        }

        [HttpGet("ListaPresentacionDeEnvaseFichaTecnica")]
        public async Task<IActionResult> Lista()
        {
            var response = new ResponseDto<List<PresentacionDeEnvaseDTO>>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _FtPresentacionDeEnvaseServicio.Lista();
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("CrearPresentacionDeEnvaseFichaTecnica")]
        public async Task<IActionResult> Crear([FromBody] PresentacionDeEnvaseDTO modelo)
        {
            var response = new ResponseDto<PresentacionDeEnvaseDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _FtPresentacionDeEnvaseServicio.Crear(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("EditarPresentacionDeEnvaseFichaTecnica")]
        public async Task<IActionResult> Editar([FromBody] PresentacionDeEnvaseDTO modelo)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = await _FtPresentacionDeEnvaseServicio.Editar(modelo);
                response.Mensaje = response.EsCorrecto ? "Presentación de envase editada con éxito." : "No se pudo editar la presentación de envase.";
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete("EliminarPresentacionDeEnvaseFichaTecnica/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = await _FtPresentacionDeEnvaseServicio.Eliminar(id);
                response.Mensaje = response.EsCorrecto ? "Presentación de envase eliminada con éxito." : "No se pudo eliminar la presentación de envase.";
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
