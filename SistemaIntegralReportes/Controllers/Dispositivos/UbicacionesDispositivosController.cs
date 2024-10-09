using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaIntegralreportes.DTO;
using SistemaIntegralReportes.DTO.Dispositivos;
using SistemaIntegralReportes.Servicios.Contrato.Dispositivos;
using SistemaIntegralReportes.Servicios.Implementacion;

namespace SistemaIntegralReportes.Controllers.Dispositivos
{
    [Route("api/[controller]")]
    [ApiController]
    public class UbicacionesDispositivosController : ControllerBase
    {

        private readonly IUbicacionesDispositivo _UbicacionDispositivo;

        public UbicacionesDispositivosController(IUbicacionesDispositivo UbicacionDispositivoServicio)
        {
            _UbicacionDispositivo = UbicacionDispositivoServicio;
        }

        [HttpGet("ListaUbicacionesDispositivos/{buscar:alpha?}")]
        public async Task<IActionResult> Lista(string buscar = "NA")
        {
            var response = new ResponseDto<List<UbicacionesDispositivosDTO>>();

            try
            {
                if (buscar == "NA") buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _UbicacionDispositivo.Lista(buscar);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("filtrarUbicacionDispositivo/{Id:int}")]

        public async Task<IActionResult> Buscar(int Id)
        {
            var response = new ResponseDto<UbicacionesDispositivosDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _UbicacionDispositivo.Buscar(Id);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("crearUbicacion")]
        public async Task<IActionResult> Crear([FromBody] UbicacionesDispositivosDTO modelo)
        {
            var response = new ResponseDto<UbicacionesDispositivosDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _UbicacionDispositivo.Crear(modelo);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("actualizarUbicacionDispositivo")]

        public async Task<IActionResult> Editar([FromBody] UbicacionesDispositivosDTO modelo)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _UbicacionDispositivo.Editar(modelo);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete("eliminarUbicacionDispositivo/{Id:int}")]
        public async Task<IActionResult> Eliminar(int Id)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _UbicacionDispositivo.Eliminar(Id);

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
