using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaIntegralReportes.DTO.FichaTecnica;
using SistemaIntegralreportes.DTO;
using SistemaIntegralReportes.Servicios.Contrato.FichaTecnica;

namespace SistemaIntegralReportes.Controllers.FichaTecnica
{
    [Route("api/[controller]")]
    [ApiController]
    public class FtCondicionAlmacenamientoController : ControllerBase
    {
        private readonly IFtCondicionAlmacenamiento _FtCondicionAlmacenamiento;

        public FtCondicionAlmacenamientoController(IFtCondicionAlmacenamiento ftCondicionAlmacenamiento)
        {
            _FtCondicionAlmacenamiento = ftCondicionAlmacenamiento;
        }

        [HttpGet("ListaCondicionAlmacenamientoFichaTecnica")]
        public async Task<IActionResult> Lista()
        {
            var response = new ResponseDto<List<CondicionDeAlmacenamientoDTO>>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _FtCondicionAlmacenamiento.Lista();
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("CrearCondicionAlmacenamientoFichaTecnica")]
        public async Task<IActionResult> Crear([FromBody] CondicionDeAlmacenamientoDTO modelo)
        {
            var response = new ResponseDto<CondicionDeAlmacenamientoDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _FtCondicionAlmacenamiento.Crear(modelo);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("EditarCondicionAlmacenamientoFichaTecnica")]
        public async Task<IActionResult> Editar([FromBody] CondicionDeAlmacenamientoDTO modelo)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = await _FtCondicionAlmacenamiento.Editar(modelo);
                response.Mensaje = response.EsCorrecto ? "Condicion editada con éxito." : "No se pudo editar la Condicion.";
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete("EliminarCondicionAlmacenamientoFichaTecnica/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = await _FtCondicionAlmacenamiento.Eliminar(id);
                response.Mensaje = response.EsCorrecto ? "Condicion eliminada con éxito." : "No se pudo eliminar la Condicion.";
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
