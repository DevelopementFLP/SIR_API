using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaIntegralReportes.DTO;
using SistemaIntegralReportes.Servicios.Contrato.FichaTecnica;
using SistemaIntegralreportes.DTO;
using SistemaIntegralReportes.DTO.FichaTecnica.CrearPlantillas;
using SistemaIntegralReportes.Servicios.Contrato.FichaTecnica.ConsultaDePlantillas;
using SistemaIntegralReportes.DTO.FichaTecnica.Plantillas;
using SistemaIntegralReportes.DTO.FichaTecnica.ConsultaDePlantillas;

namespace SistemaIntegralReportes.Controllers.FichaTecnica
{
    [Route("api/[controller]")]
    [ApiController]
    public class FtPlantillasController : ControllerBase
    {
        private readonly IFtAspectosGeneralesPlantilla _servicioAspectosGenerales;
        private readonly IFtEspecificacionesPlantilla _servicioEspecificaciones;
        private readonly IFtResponseAspectosGeneralesPlantilla _servicioResponseAspectosGenerales;
        private readonly IFtResponseEspecificacionesPlantilla _servicioResponseEspecificaciones;

        // Constructor del servicio
        public FtPlantillasController(
            IFtAspectosGeneralesPlantilla servicioAspectosGenerales,
            IFtEspecificacionesPlantilla servicioEspecificaciones,
            IFtResponseAspectosGeneralesPlantilla servicioResponseAspectosGenerales,
            IFtResponseEspecificacionesPlantilla servicioResponseEspecificaciones)
        {
            _servicioAspectosGenerales = servicioAspectosGenerales;
            _servicioEspecificaciones = servicioEspecificaciones;
            _servicioResponseAspectosGenerales = servicioResponseAspectosGenerales;
            _servicioResponseEspecificaciones = servicioResponseEspecificaciones;
        }

        [HttpGet("ListaAspectosGenerales")]
        public async Task<IActionResult> ListaAspectosGenerales()
        {
            var response = new ResponseDto<List<AspectosGeneralesPlantillaDTO>>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _servicioAspectosGenerales.ListaDeAspectosGenerales();
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost("CrearAspectoGeneral")]
        public async Task<IActionResult> Crear([FromBody] AspectosGeneralesPlantillaDTO modelo)
        {
            var response = new ResponseDto<AspectosGeneralesPlantillaDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _servicioAspectosGenerales.Crear(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("BuscarPlantillaAspectosGenerales")]
        public async Task<IActionResult> BuscarPlantillaAspectosGenerales(string descripcionDePlantilla)
        {
            var response = new ResponseDto<AspectosGeneralesPlantillaDTO>();

            try
            {
                var resultado = await _servicioAspectosGenerales.BuscarPlantillaAspectosGenerales(descripcionDePlantilla);

                if (resultado == null)
                {
                    response.EsCorrecto = false;
                    response.Mensaje = "No se encontró la plantilla.";
                }
                else
                {
                    response.EsCorrecto = true;
                    response.Resultado = resultado;
                }
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }


        [HttpPut("EditarAspectoGeneral")]
        public async Task<IActionResult> Editar([FromBody] AspectosGeneralesPlantillaDTO modelo)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = await _servicioAspectosGenerales.Editar(modelo);
                if (response.EsCorrecto)
                {
                    response.Mensaje = "Aspecto general editado correctamente.";
                }
                else
                {
                    response.Mensaje = "No se encontró el aspecto general para editar.";
                }
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }


        [HttpGet("ListaDeEspecificaciones")]
        public async Task<IActionResult> ListaEspecificaciones()
        {
            var response = new ResponseDto<List<EspecificacionesPlantillaDTO>>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _servicioEspecificaciones.ListaDeEspecificaciones();
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet("BuscarPlantillaEspecificaciones")]
        public async Task<IActionResult> BuscarPlantillaEspecificaciones(string nombreDePlantilla)
        {
            var response = new ResponseDto<EspecificacionesPlantillaDTO>();

            try
            {
                var resultado = await _servicioEspecificaciones.BuscarPlantillaEspecificaciones(nombreDePlantilla);

                if (resultado == null)
                {
                    response.EsCorrecto = false;
                    response.Mensaje = "No se encontró la plantilla de especificaciones.";
                }
                else
                {
                    response.EsCorrecto = true;
                    response.Resultado = resultado;
                }
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPut("EditarEspecificaciones")]
        public async Task<IActionResult> Editar([FromBody] EspecificacionesPlantillaDTO modelo)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = await _servicioEspecificaciones.Editar(modelo);
                if (response.EsCorrecto)
                {
                    response.Mensaje = "Especificación editada correctamente.";
                }
                else
                {
                    response.Mensaje = "No se encontró la especificación para editar.";
                }
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }



        [HttpPost("CrearEspecificacion")]
        public async Task<IActionResult> CrearEspecificacion([FromBody] EspecificacionesPlantillaDTO modelo)
        {
            var response = new ResponseDto<EspecificacionesPlantillaDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _servicioEspecificaciones.Crear(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }        


        [HttpGet("ConsultarAspectosGenerales")]
        public async Task<IActionResult> ConsultarAspectosGenerales(int idPlantilla)
        {
            var response = new ResponseDto<List<ResponseAspectosGeneralesDTO>>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _servicioResponseAspectosGenerales.ObtenerAspectosGeneralesPlantilla(idPlantilla);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet("ConsultarEspecificaciones")]
        public async Task<IActionResult> ConsultarEspecificaciones(int idPlantilla)
        {
            var response = new ResponseDto<List<ResponseEspecificacionesDTO>>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _servicioResponseEspecificaciones.ObtenerEspecificacionesPlantilla(idPlantilla);
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
