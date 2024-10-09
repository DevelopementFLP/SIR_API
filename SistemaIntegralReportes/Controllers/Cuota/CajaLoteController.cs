using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.DTO.Cuota;
using System.Configuration;
using System.Data;

namespace SistemaIntegralReportes.Controllers.Cuota
{
    [Route("api/[controller]")]
    [ApiController]
    public class CajaLoteController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _innovaConnectionString;
        private readonly string _sirConnectionString;

        public CajaLoteController(IConfiguration configuration)
        {
            _configuration = configuration;
            _innovaConnectionString = configuration.GetConnectionString("InnovaProduccion");
            _sirConnectionString = configuration.GetConnectionString("SqlTestConection");
        }

        [HttpGet("GetLotesEntradaAsync")]
        public async Task<IEnumerable<SalidaDTO>> GetLotesEntradaAsync(DateTime fechaProduccion, string lotes)
        {
            var storedProcedure = _configuration.GetSection("ReporteCuota:CajasPorLoteYFecha").Value;

            using (var connection = new SqlConnection(_innovaConnectionString))
            {
                if (connection == null) return Enumerable.Empty<SalidaDTO>();

                try
                {
                    connection.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("@fechaProduccion", fechaProduccion, DbType.DateTime);
                    parameters.Add("@lotes", lotes, DbType.String);

                    var cajas = await connection.QueryAsync<SalidaDTO>(storedProcedure, parameters, commandType: CommandType.Text);

                    return cajas;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al ejecutar el procedimiento almacenado: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

        }

        [HttpGet("GetDWCortesPorFechaYLoteAsync")]
        public async Task<IEnumerable<DWSalidaDTO>> GetDWCortesPorFechaYLoteAsync(DateTime fechaProduccionDesde, DateTime fechaProduccionHasta, string lotesStr)
        {
            var query = _configuration.GetSection("ReporteCuota:DWCortesPorLoteYFecha").Value;
            query = query.Replace("@lotes", lotesStr);

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return Enumerable.Empty<DWSalidaDTO>();

                try
                {
                    connection.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("@fechaDesde", fechaProduccionDesde, DbType.DateTime);
                    parameters.Add("@fechaHasta", fechaProduccionHasta, DbType.DateTime);

                    var cortes = await connection.QueryAsync<DWSalidaDTO>(query, parameters, commandType: CommandType.Text);

                    return cortes;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al ejecutar el procedimiento almacenado: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        [HttpGet("GetDWCajaLoteAsync")]
        public async Task<IEnumerable<DWCajaSalidaDTO>> GetDWCajaLoteAsync(DateTime fechaProduccionDesde, DateTime fechaProduccionHasta, string? filtro = "")
        {
            var query = _configuration.GetSection("ReporteCuota:DWCajasPorFechaYTipo").Value;

            if (!string.IsNullOrEmpty(filtro))
            {
                query += " AND customercode LIKE @filtro";
            }

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return Enumerable.Empty<DWCajaSalidaDTO>();

                try
                {
                    connection.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("@fechaDesde", fechaProduccionDesde, DbType.DateTime);
                    parameters.Add("@fechaHasta", fechaProduccionHasta, DbType.DateTime);

                    if (!string.IsNullOrEmpty(filtro))
                    {
                        parameters.Add("@filtro", $"%{filtro}%", DbType.String);
                    }

                    var cajas = await connection.QueryAsync<DWCajaSalidaDTO>(query, parameters, commandType: CommandType.Text);

                    return cajas;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al ejecutar la consulta: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

    }

}
