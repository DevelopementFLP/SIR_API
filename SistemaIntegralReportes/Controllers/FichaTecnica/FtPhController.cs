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
    public class FtPhController : ControllerBase
    {
        private readonly IFtPh _FtPhServicio;

        // Constructor del servicio
        public FtPhController(IFtPh ftPhServicio)
        {
            _FtPhServicio = ftPhServicio;
        }

        [HttpGet("ListaPhFichaTecnica")]
        public async Task<IActionResult> Lista()
        {
            var response = new ResponseDto<List<PhDTO>>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _FtPhServicio.Lista();
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("CrearPhFichaTecnica")]
        public async Task<IActionResult> Crear([FromBody] PhDTO modelo)
        {
            var response = new ResponseDto<PhDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _FtPhServicio.Crear(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("EditarPhFichaTecnica")]
        public async Task<IActionResult> Editar([FromBody] PhDTO modelo)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = await _FtPhServicio.Editar(modelo);
                response.Mensaje = response.EsCorrecto ? "pH editado con éxito." : "No se pudo editar el pH.";
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete("EliminarPhFichaTecnica/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = await _FtPhServicio.Eliminar(id);
                response.Mensaje = response.EsCorrecto ? "pH eliminado con éxito." : "No se pudo eliminar el pH.";
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
