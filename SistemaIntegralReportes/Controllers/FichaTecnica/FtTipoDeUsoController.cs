using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaIntegralReportes.DTO.FichaTecnica;
using SistemaIntegralreportes.DTO;
using SistemaIntegralReportes.Servicios.Contrato.FichaTecnica;

namespace SistemaIntegralReportes.Controllers.FichaTecnica
{
    [Route("api/[controller]")]
    [ApiController]
    public class FtTipoDeUsoController : ControllerBase
    {
        private readonly IFtTipoDeUso _FtTipoDeUsoServicio;

        // Constructor del servicio
        public FtTipoDeUsoController(IFtTipoDeUso ftTipoDeUsoServicio)
        {
            _FtTipoDeUsoServicio = ftTipoDeUsoServicio;
        }

        [HttpGet("ListaTiposDeUsoFichaTecnica")]
        public async Task<IActionResult> Lista()
        {
            var response = new ResponseDto<List<TipoDeUsoDTO>>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _FtTipoDeUsoServicio.Lista();
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("CrearTipoDeUsoFichaTecnica")]
        public async Task<IActionResult> Crear([FromBody] TipoDeUsoDTO modelo)
        {
            var response = new ResponseDto<TipoDeUsoDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _FtTipoDeUsoServicio.Crear(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("EditarTipoDeUsoFichaTecnica")]
        public async Task<IActionResult> Editar([FromBody] TipoDeUsoDTO modelo)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = await _FtTipoDeUsoServicio.Editar(modelo);
                response.Mensaje = response.EsCorrecto ? "Tipo de uso editado con éxito." : "No se pudo editar el tipo de uso.";
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete("EliminarTipoDeUsoFichaTecnica/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = await _FtTipoDeUsoServicio.Eliminar(id);
                response.Mensaje = response.EsCorrecto ? "Tipo de uso eliminado con éxito." : "No se pudo eliminar el tipo de uso.";
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
