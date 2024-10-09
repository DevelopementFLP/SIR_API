using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.DTO.Cuota;
using SistemaIntegralReportes.DTO.Rendimiento;
using System.Data;

namespace SistemaIntegralReportes.Controllers.Rendimientos
{
    [Route("api/[controller]")]
    [ApiController]
    public class RendimientosController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _sirConnectionString;
        private readonly string _innovaConnectionString;

        public RendimientosController(IConfiguration configuration)
        {
            _configuration = configuration;
            _sirConnectionString = configuration.GetConnectionString("SqlTestConection");
            _innovaConnectionString = configuration.GetConnectionString("InnovaProduccion");
        }

        [HttpGet("GetCortesPorLoteYFecha")]
        public async Task<IEnumerable<CorteDataDTO>> GetCortesPorLoteYFecha(DateTime fechaProduccionDesde, DateTime fechaProduccionHasta, string lotesStr)
        {
            var storedProcedure = _configuration.GetSection("Rendimientos:GetCortesPorLoteYFecha").Value;

            using (var connection = new SqlConnection(_innovaConnectionString))
            {
                if (connection == null) return Enumerable.Empty<CorteDataDTO>();

                try
                {
                    connection.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("@fechaProduccionDesde", fechaProduccionDesde, DbType.DateTime);
                    parameters.Add("@fechaProduccionHasta", fechaProduccionHasta, DbType.DateTime);
                    parameters.Add("@lotesStr", lotesStr, DbType.String);

                    var cortes = await connection.QueryAsync<CorteDataDTO>(storedProcedure, parameters, commandType: CommandType.Text);

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

        [HttpGet("GetConfigTipoRendimiento")]
        public async Task<IEnumerable<ConfTipoRendimiento>> GetConfigTipoRendimiento()
        {
            var query = _configuration.GetSection("Rendimientos:GetConfigTipoRendimiento").Value;

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return Enumerable.Empty<ConfTipoRendimiento>();

                try
                {
                    connection.Open();
                    var tipos = await connection.QueryAsync<ConfTipoRendimiento>(query, commandType: CommandType.Text);

                    return tipos;
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

        [HttpGet("GetLotesPorTipo")]
        public async Task<IEnumerable<LotePorTipo>> GetLotesPorTipo(int idTipo)
        {
            var query = _configuration.GetSection("Rendimientos:GetLotesPorTipo").Value;
            query = query.Replace("@idTipo", idTipo.ToString());

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return Enumerable.Empty<LotePorTipo>();

                try
                {
                    connection.Open();
                    var lotes = await connection.QueryAsync<LotePorTipo>(query, commandType: CommandType.Text);

                    return lotes;
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

        [HttpGet("GetLotesActivos")]
        public async Task<IEnumerable<TipoLote>> GetLotesActivos()
        {
            var query = _configuration.GetSection("Rendimientos:GetLotesActivos").Value;

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return Enumerable.Empty<TipoLote>();

                try
                {
                    connection.Open();
                    var lotes = await connection.QueryAsync<TipoLote>(query, commandType: CommandType.Text);

                    return lotes;
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
