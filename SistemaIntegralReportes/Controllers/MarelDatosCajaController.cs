using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.Models;
using System.Configuration;
using System.Data;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;
using Dapper;

namespace SistemaIntegralReportes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class MarelDatosCajaController : ControllerBase
    {
        public HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string? _innovaConnectionString;
        private bool _connectionOK = false;
        private SqlConnection? _dbConnection = null;
        private SqlCommand? _command = null;
        private SqlDataReader? _reader = null;


        public MarelDatosCajaController(HttpClient httpClient, IConfiguration configuration)
        {
            _innovaConnectionString = configuration.GetConnectionString("InnovaConnectionString");
            _connectionOK = _innovaConnectionString != null;
            _configuration = configuration;
        }

        [HttpGet("getDatosCaja")]
        public async Task<ActionResult> getDatosCaja([FromQuery] string id)
        {
            var query = $"select pp.extcode, pp.prday, pp.expire3, pm.code, pm.name, pm.customercode from proc_packs pp inner join proc_materials pm on pm.material = pp.material where pp.extcode ='{id}'";

            DataTable dt = new DataTable();

            if (_connectionOK)
            {

                try
                {
                    _dbConnection = new SqlConnection(_innovaConnectionString);
                    _command = new SqlCommand();
                    _command.CommandText = query;
                    _command.CommandType = CommandType.Text;
                    _command.Connection = _dbConnection;

                    _dbConnection.Open();
                    _reader = _command.ExecuteReader();
                    dt.Load(_reader);
                    _dbConnection.Close();
                }
                catch (Exception)
                {
                    if (_dbConnection != null) _dbConnection.Close();
                }
            }

            if (dt.Rows.Count > 0) 
            {
                string json = JsonConvert.SerializeObject(dt.Rows[0].Table);
                return Ok(json);
            } 
            else return NotFound();
        }

        [HttpGet("GetSalidaMarel")]
        public async Task<IEnumerable<DatoSalida>> GetSalidaMarel(string fechaDesde, string fechaHasta)
        {
            var query = _configuration.GetSection("SalidaMarel").Value.ToString();

            using (var sqlConnection = new SqlConnection(_innovaConnectionString))
            {
                if (sqlConnection == null) return null;
                //sqlConnection.ConnectionString = _configuration.GetConnectionString("HPConnectionString");
                sqlConnection.Open();

                var paramFechaDesde = new SqlParameter("@fechaDesde", SqlDbType.NVarChar);
                var paramFechaHasta = new SqlParameter("@fechaHasta", SqlDbType.NVarChar);
                paramFechaDesde.Value = fechaDesde;
                paramFechaHasta.Value = fechaHasta;

                var salida = await sqlConnection.QueryAsync<DatoSalida>(query, new { startingTime = fechaDesde, endTime = fechaHasta}, commandType: CommandType.Text);
                sqlConnection.Close();
                return salida;

            }
        }

        [HttpGet("GetEntradaMarel")]
        public async Task<IEnumerable<DatoEntrada>> GetEntradaMarel(string fechaDesde, string fechaHasta)
        {
            var query = _configuration.GetSection("EntradaMarel").Value.ToString();

            using (var sqlConnection = new SqlConnection(_innovaConnectionString))
            {
                if (sqlConnection == null) return null;
                //sqlConnection.ConnectionString = _configuration.GetConnectionString("HPConnectionString");
                sqlConnection.Open();

                var paramFechaDesde = new SqlParameter("@fechaDesde", SqlDbType.NVarChar);
                var paramFechaHasta = new SqlParameter("@fechaHasta", SqlDbType.NVarChar);
                paramFechaDesde.Value = fechaDesde;
                paramFechaHasta.Value = fechaHasta;

                var entrada = await sqlConnection.QueryAsync<DatoEntrada>(query, new { fechaDesde = fechaDesde, fechaHasta = fechaHasta }, commandType: CommandType.Text);
                sqlConnection.Close();
                return entrada;

            }
        }
    }
}
