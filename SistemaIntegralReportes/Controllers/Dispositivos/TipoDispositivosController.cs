using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaIntegralreportes.DTO;
using SistemaIntegralReportes.Servicios.Contrato;
using SistemaIntegralReportes.Servicios.Implementacion;

namespace SistemaIntegralReportes.Controllers.Dispositivos
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDispositivosController : ControllerBase
    {
        private readonly ITipoDispositivo _tipoDispositivoServicio;

        public TipoDispositivosController(ITipoDispositivo TipoDispositivoServicio)
        {
            _tipoDispositivoServicio = TipoDispositivoServicio;
        }

        [HttpGet("ListaTiposDispositivos/{buscar:alpha?}")]
        public async Task<IActionResult> Lista(string buscar = "NA")
        {
            var response = new ResponseDto<List<TipoDispositivoDTO>>();

            try
            {
                if (buscar == "NA") buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _tipoDispositivoServicio.Lista(buscar);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("filtrarTipoDipositivo/{Id:int}")]

        public async Task<IActionResult> Buscar(int Id)
        {
            var response = new ResponseDto<TipoDispositivoDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _tipoDispositivoServicio.Buscar(Id);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("crearTipoDispositivo")]
        public async Task<IActionResult> Crear([FromBody] TipoDispositivoDTO modelo)
        {
            var response = new ResponseDto<TipoDispositivoDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _tipoDispositivoServicio.Crear(modelo);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("actualizarTipoDeDispositivo")]

        public async Task<IActionResult> Editar([FromBody] TipoDispositivoDTO modelo)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _tipoDispositivoServicio.Editar(modelo);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete("eliminarTipoDispositivo/{Id:int}")]
        public async Task<IActionResult> Eliminar(int Id)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _tipoDispositivoServicio.Eliminar(Id);

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
