using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaIntegralreportes.DTO;
using SistemaIntegralReportes.Servicios.Contrato;

namespace SistemaIntegralReportes.Controllers.Dispositivos
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormateosController : ControllerBase
    {
        private readonly IFormateoDispositivo _formateoServicio;

        public FormateosController(IFormateoDispositivo formateoServicio)
        {
            _formateoServicio = formateoServicio;
        }

        [HttpGet("ListaFormatosDispositivos/{buscar:alpha?}")]
        public async Task<IActionResult> Lista(string buscar = "NA")
        {
            var response = new ResponseDto<List<FormateosDTO>>();

            try
            {
                if (buscar == "NA") buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _formateoServicio.Lista(buscar);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("filtrarFormatos/{Id:int}")]

        public async Task<IActionResult> Buscar(int Id)
        {
            var response = new ResponseDto<FormateosDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _formateoServicio.Buscar(Id);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("crearFormato")]
        public async Task<IActionResult> Crear([FromBody] FormateosDTO modelo)
        {
            var response = new ResponseDto<FormateosDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _formateoServicio.Crear(modelo);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("actualizarFormato")]

        public async Task<IActionResult> Editar([FromBody] FormateosDTO modelo)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _formateoServicio.Editar(modelo);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete("eliminarFormato/{Id:int}")]
        public async Task<IActionResult> Eliminar(int Id)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _formateoServicio.Eliminar(Id);

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
