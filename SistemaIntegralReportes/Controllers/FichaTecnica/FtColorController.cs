using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaIntegralReportes.DTO.FichaTecnica;
using SistemaIntegralreportes.DTO;
using SistemaIntegralReportes.Servicios.Contrato.FichaTecnica;

namespace SistemaIntegralReportes.Controllers.FichaTecnica
{
    [Route("api/[controller]")]
    [ApiController]
    public class FtColorController : ControllerBase
    {
        private readonly IFtColor _FtColorServicio;

        //Creo el constructor del servicio
        public FtColorController(IFtColor ftColorServicio)
        {
            _FtColorServicio = ftColorServicio;
        }

        [HttpGet("ListaColoresFichaTecnica")]
        public async Task<IActionResult> Lista()
        {
            var response = new ResponseDto<List<ColorDTO>>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _FtColorServicio.Lista();
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("CrearMarcaFichaTecnica")]
        public async Task<IActionResult> Crear([FromBody] ColorDTO modelo)
        {
            var response = new ResponseDto<ColorDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _FtColorServicio.Crear(modelo);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("EditarMarcaFichaTecnica")]
        public async Task<IActionResult> Editar([FromBody] ColorDTO modelo)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = await _FtColorServicio.Editar(modelo);
                response.Mensaje = response.EsCorrecto ? "Color editado con éxito." : "No se pudo editar el Color.";
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete("EliminarMarcaFichaTecnica/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = await _FtColorServicio.Eliminar(id);
                response.Mensaje = response.EsCorrecto ? "Color eliminado con éxito." : "No se pudo eliminar el Color.";
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
