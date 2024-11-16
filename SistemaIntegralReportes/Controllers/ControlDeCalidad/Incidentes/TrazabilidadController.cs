using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaIntegralReportes.DTO.ControlDeCalidad.Incidentes;
using SistemaIntegralreportes.DTO;
using SistemaIntegralReportes.Servicios.Contrato.FichaTecnica;
using SistemaIntegralReportes.Servicios.Contrato.ControlDeCalidad.Incidentes;

namespace SistemaIntegralReportes.Controllers.ControlDeCalidad.Incidentes
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrazabilidadController : ControllerBase
    {
        private readonly ITrazabilidad _trazabilidadService;
        private readonly ITipoDeIncidente _tiposDeIncidentes;
        private readonly IRegistroDeIncidente _registroDeIncidente;

        public TrazabilidadController(ITrazabilidad trazabilidad, ITipoDeIncidente tiposDeIncidentes, IRegistroDeIncidente registroDeIncidente )
        {
            _trazabilidadService = trazabilidad;
            _tiposDeIncidentes = tiposDeIncidentes;
            _registroDeIncidente = registroDeIncidente;
        }

        [HttpGet("ListaTrazabilidad")]
        public async Task<IActionResult> Lista(int codigoQr)
        {
            var response = new ResponseDto<List<TrazabilidadDTO>>();

            try
            {
                // Llamamos al servicio para obtener la lista de trazabilidad
                response.EsCorrecto = true;
                response.Resultado = await _trazabilidadService.BuscarTrazabilidad(codigoQr);
            }
            catch (Exception ex)
            {
                // Si ocurre algún error, configuramos el mensaje
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            // Devolvemos la respuesta en formato JSON
            return Ok(response);
        }


        [HttpGet("ListaDeTiposDeIncidente")]
        public async Task<IActionResult> Lista()
        {
            var response = new ResponseDto<List<TipoDeIncidenteDTO>>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _tiposDeIncidentes.ListaDeTipoDeIncidente();
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }


        [HttpPost("CrearIncidente")]

        public async Task<IActionResult> CrearIncidente(
            [FromForm] string codigoQr,
            [FromForm] string PuestoDeTrabajo,
            [FromForm] string Empleado,
            [FromForm] string Producto,
            [FromForm] string Hora,
            [FromForm] int IdTipoDeIncidente,
            [FromForm] IFormFile imagenFile)
        {
            var response = new ResponseDto<RegistroDeIncidenteDTO>();

            try
            {
                byte[] imagenBytes = null;

                // Convertir la imagen de IFormFile a byte[]
                if (imagenFile != null && imagenFile.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await imagenFile.CopyToAsync(memoryStream);
                        imagenBytes = memoryStream.ToArray();
                    }
                }

                response.Resultado = await _registroDeIncidente.Crear(
                    codigoQr,
                    PuestoDeTrabajo,
                    Empleado,
                    Producto,
                    Hora,
                    IdTipoDeIncidente,
                    imagenBytes
                );

                response.EsCorrecto = true;
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }



        [HttpGet("ListaDeIncidentes")]
        public async Task<IActionResult> ListaDeIncidentes(string fechaDelDia)
        {
            var response = new ResponseDto<List<IncidentesDTO>>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _registroDeIncidente.ListaDeIncidentes(fechaDelDia);
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
