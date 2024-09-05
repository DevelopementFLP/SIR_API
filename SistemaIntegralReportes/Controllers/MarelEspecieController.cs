using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.Models;
using System.Data;

namespace SistemaIntegralReportes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class MarelEspecieController : ControllerBase
    {
        public HttpClient _httpClient;
        public IConfiguration _configuration;
        private string? _innovaConnectionString;
        private bool _connectionOK = false;
        private SqlConnection? _dbConnection = null;
        private SqlCommand? _command = null;
        private SqlDataReader? _reader = null;


        public MarelEspecieController(HttpClient httpClient, IConfiguration configuration) {
            _innovaConnectionString = configuration.GetConnectionString("InnovaConnectionString");
            _connectionOK = _innovaConnectionString != null;
        }

        [HttpGet("getEspeciePorCodigo")]
        public async Task<ActionResult<string>> GetEspeciePorCodigo([FromQuery] string codigo)
        {
            var query = $"select condition from proc_materials where code = '{codigo}'";

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

            return (dt.Rows.Count > 0) ? Ok(dt.Rows[0].ItemArray[0].ToString()) : NotFound();
        }
    }
}
