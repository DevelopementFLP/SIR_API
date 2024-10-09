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
    public class ReporteCuotaController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _sirConnectionString;
        private readonly string _innovaConnectionString;

        public ReporteCuotaController(IConfiguration configuration)
        {
            _configuration = configuration;
            _sirConnectionString = configuration.GetConnectionString("SqlTestConection");
            _innovaConnectionString = configuration.GetConnectionString("InnovaProduccion");
        }

        [HttpGet("GetTipoCuotaAsync")]
        public async Task<IEnumerable<ConfTipoCuotaDTO>> GetTipoCuotaAsync()
        {
            var query = _configuration.GetSection("ReporteCuota:GetConfTipoCuota").Value;

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return Enumerable.Empty<ConfTipoCuotaDTO>();

                try
                {
                    connection.Open();
                    var tipos = await connection.QueryAsync<ConfTipoCuotaDTO>(query, commandType: CommandType.Text);

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

        [HttpGet("GetConfReporteCuotaAsync")]
        public async Task<IEnumerable<ConfReporteCuotaDTO>> GetConfReporteCuotaAsync()
        {
            var query = _configuration.GetSection("ReporteCuota:GetConfReporteCuota").Value;

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return Enumerable.Empty<ConfReporteCuotaDTO>();

                try
                {
                    connection.Open();
                    var conf = await connection.QueryAsync<ConfReporteCuotaDTO>(query, commandType: CommandType.Text);

                    return conf;
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

        [HttpGet("GetLotesAsync")]
        public async Task<IEnumerable<LoteDTO>> GetLotesAsync(string lotes)
        {
            var query = _configuration.GetSection("ReporteCuota:GetLotes").Value;
            query = query.Replace("@lotes", lotes);
            using (var connection = new SqlConnection(_innovaConnectionString))
            {
                if (connection == null) return Enumerable.Empty<LoteDTO>();

                try
                {
                    connection.Open();
                    var lotesRes = await connection.QueryAsync<LoteDTO>(query, commandType: CommandType.Text);

                    return lotesRes;
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

        [HttpGet("GetQamarks")]
        public async Task<IEnumerable<QamarkDTO>> GetQamarks()
        {
            var query = _configuration.GetSection("ReporteCuota:GetQamarks").Value;
            using (var connection = new SqlConnection(_innovaConnectionString))
            {
                if (connection == null) return Enumerable.Empty<QamarkDTO>();
                try
                {
                    connection.Open();
                    var qamarks = await connection.QueryAsync<QamarkDTO>(query, commandType: CommandType.Text);
                    return qamarks;

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

        [HttpGet("InsertarDatosDWAsync")]
        public async Task InsertarDatosDWAsync()
        {
            var query = _configuration.GetSection("ReporteCuota:InsertarDatosEnDW").Value;
            using (var connection = new SqlConnection(_innovaConnectionString))
            {
                if (connection == null) return;
                try
                {
                    connection.Open();
                    await connection.QueryAsync<QamarkDTO>(query, commandType: CommandType.Text);
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
