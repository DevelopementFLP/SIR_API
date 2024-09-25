using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaIntegralreportes.DTO;
using SistemaIntegralReportes.Models.Faena.Reportes;
using SistemaIntegralReportes.Models.Reportes;
using SistemaIntegralReportes.Servicios.Contrato;
using SistemaIntegralReportes.Servicios.Contrato.Faena;

namespace SistemaIntegralReportes.Controllers.Faena
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteDeMediasController : ControllerBase
    {
        private readonly IReporteDeFaena _reporteDeFaena;

        //Creo el constructor del servicio
        public ReporteDeMediasController(IReporteDeFaena reporteDeFaena)
        {
            _reporteDeFaena = reporteDeFaena;
        }

        [HttpGet("reporteDeMediasPorProducto")]
        public async Task<IActionResult> GetReportePorProducto(string fechaDesde, string fechaHasta, string horaDesde, string horaHasta)
        {
            var response = new ResponseDto<List<ReporteDeMediasProductoDTO>>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _reporteDeFaena.GetReportePorProducto(fechaDesde, fechaHasta, horaDesde, horaHasta);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("reporteDeMediasPorProveedor")]
        public async Task<IActionResult> GetReportePorProveedor(string fechaDesde, string fechaHasta, string horaDesde, string horaHasta)
        {
            var response = new ResponseDto<List<ReporteDeMediasProveedorDTO>>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _reporteDeFaena.GetReportePorProveedor(fechaDesde, fechaHasta, horaDesde, horaHasta);

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
