using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.DTO.Abasto;
using SistemaIntegralreportes.DTO;
using SistemaIntegralReportes.Models;
using System.Configuration;
using System.Data;
using SistemaIntegralReportes.Models.Configuraciones;

namespace SistemaIntegralReportes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        public HttpClient? _httpClient;
        private readonly IConfiguration _configuration;
        //private string? _innovaConnectionString;
        private string? _sirConnectionString;

        public ConfigurationController(IConfiguration configuration)
        {
            //_innovaConnectionString = configuration.GetConnectionString("InnovaProduccion");
            _sirConnectionString = configuration.GetConnectionString("SqlTestConection");
            _configuration = configuration;
        }

        #region Métodos asíncronos
        [HttpGet("GetConfiguracionPorModuloAsync")]
        public async Task<IEnumerable<ConfigurationParameter>> GetConfiguracionPorModuloAsync(int moduloId)
        {
            var query = _configuration.GetSection("ConfigurationParameters:GetConfigurationParametersByModulo").Value;

            using (var sqlConnection = new SqlConnection(_sirConnectionString))
            {
                if (sqlConnection == null) return null;

                try
                {
                    await sqlConnection.OpenAsync();
                    query = query.Replace("@moduloId", moduloId.ToString());


                    var conf = await sqlConnection.QueryAsync<ConfigurationParameter>(query, commandType: CommandType.Text);
                    sqlConnection.Close();
                    return conf;
                }
                catch (Exception e)
                {
                    if (sqlConnection != null)
                        await sqlConnection.CloseAsync();

                    throw new Exception(e.Message);
                }
            }
        }

        [HttpDelete("InactivarReporteConfiguracionParametroAsync")]
        public async void InactivarReporteConfiguracionParametroAsync(int id)
        {
            var query = _configuration.GetSection("ConfigurationParameters:InactivarReporteConfigurationParameter").Value;

            using (var sqlConnection = new SqlConnection(_sirConnectionString))
            {
                if (sqlConnection == null) return;

                try
                {
                    await sqlConnection.OpenAsync();
                    query = query.Replace("@id", id.ToString());


                    var conf = await sqlConnection.QueryAsync<ConfigurationParameter>(query, commandType: CommandType.Text);
                    sqlConnection.Close();
                }
                catch (Exception e)
                {
                    if (sqlConnection != null)
                        await sqlConnection.CloseAsync();

                    throw new Exception(e.Message);
                }
            }
        }

        [HttpDelete("DeleteReporteConfiguracionParametroAsync")]
        public async void DeleteReporteConfiguracionParametroAsync(int id)
        {
            var query = _configuration.GetSection("ConfigurationParameters:DeleteReporteConfigurationParameter").Value;

            using (var sqlConnection = new SqlConnection(_sirConnectionString))
            {
                if (sqlConnection == null) return;

                try
                {
                    await sqlConnection.OpenAsync();
                    query = query.Replace("@id", id.ToString());


                    var conf = await sqlConnection.QueryAsync<ConfigurationParameter>(query, commandType: CommandType.Text);
                    sqlConnection.Close();
                }
                catch (Exception e)
                {
                    if (sqlConnection != null)
                        await sqlConnection.CloseAsync();

                    throw new Exception(e.Message);
                }
            }
        }

        [HttpPost("InsertReporteConfigurationParameterAsync")]
        public async Task<IActionResult> InsertReporteConfigurationParameterAsync([FromBody] ConfigurationParameter configurationParameter)
        {
            var query = _configuration.GetSection("ConfigurationParameters:InsertReporteConfigurationParameter").Value;

            using (var sqlConnection = new SqlConnection(_sirConnectionString))
            {
                if (sqlConnection == null) return BadRequest(ConnectionState.Closed);

                try
                {
                    await sqlConnection.OpenAsync();
                    query = query.Replace("@reporteId", configurationParameter.ReporteId.ToString());
                    query = query.Replace("@moduloId", configurationParameter.ModuloId.ToString());
                    query = query.Replace("@nombre", configurationParameter.Nombre.ToString());
                    query = query.Replace("@valor", configurationParameter.Valor.ToString());
 


                    var conf = await sqlConnection.QueryAsync<ConfigurationParameter>(query, commandType: CommandType.Text);
                    sqlConnection.Close();
                    return Ok();
                }
                catch (Exception e)
                {
                    if (sqlConnection != null)
                        await sqlConnection.CloseAsync();
                    
                    throw new Exception(e.Message);
                }
            }
        }

        [HttpPatch("ActivarReporteConfiguracionParametroAsync")]
        public async Task<IActionResult> ActivarReporteConfiguracionParametroAsync(int id)
        {
            var query = _configuration.GetSection("ConfigurationParameters:ActivarReporteConfigurationParameter").Value;

            using (var sqlConnection = new SqlConnection(_sirConnectionString))
            {
                if (sqlConnection == null) return BadRequest(ConnectionState.Closed);

                try
                {
                    await sqlConnection.OpenAsync();
                    query = query.Replace("@id", id.ToString());


                    var conf = await sqlConnection.QueryAsync<ConfigurationParameter>(query, commandType: CommandType.Text);
                    sqlConnection.Close();
                    return Ok();
                }
                catch (Exception e)
                {
                    if (sqlConnection != null)
                        await sqlConnection.CloseAsync();

                    throw new Exception(e.Message);
                }
            }
        }
        #endregion
    }   
}
