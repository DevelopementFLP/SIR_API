using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.DTO.Cuota;
using SistemaIntegralReportes.Models.StockCajas;
using System.Data;

namespace SistemaIntegralReportes.Controllers.Cuota
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoteEntradaController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _innovaConnectionString;
        public LoteEntradaController(IConfiguration configuration) 
        {
            _configuration = configuration;
            _innovaConnectionString = configuration.GetConnectionString("InnovaProduccion");
        }

        [HttpGet("GetLotesEntradaAsync")]
        public async Task<IEnumerable<LoteEntradaDTO>> GetLotesEntradaAsync(DateTime fechaProduccionDesde, DateTime fechaProduccionHasta, string lotesStr)
        {
            var storedProcedure = _configuration.GetSection("ReporteCuota:EntradaPorLotesYFechas").Value;

            using (var connection = new SqlConnection(_innovaConnectionString))
            {
                if (connection == null) return Enumerable.Empty<LoteEntradaDTO>();

                try
                {
                    connection.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("@fechaProduccionDesde", fechaProduccionDesde, DbType.DateTime);
                    parameters.Add("@fechaProduccionHasta", fechaProduccionHasta, DbType.DateTime);
                    parameters.Add("@lotesStr", lotesStr, DbType.String);

                    var lotes = await connection.QueryAsync<LoteEntradaDTO>(storedProcedure, parameters, commandType: CommandType.Text);

                    return lotes;
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

    }
}
