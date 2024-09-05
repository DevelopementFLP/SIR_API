using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.Models;
using System.Data;

namespace SistemaIntegralReportes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string? _sqlTestConnectionString;
        private bool _connectionOK = false;
        private SqlConnection? _dbConnection = null;
        private SqlCommand? _command = null;
        private SqlDataReader? _reader = null;

        public UserController(HttpClient httpclient, IConfiguration configuration)
        {
            _sqlTestConnectionString = configuration.GetConnectionString("SqlTestConection");
            _connectionOK = _sqlTestConnectionString != null;
            _configuration = configuration;
        }

        [HttpPatch("CambiarContrasenia")]
        public async Task<IActionResult> GetFuncionariosLogueados(string contrasenia, int id)
        {
            var query = _configuration.GetSection("CambiarContrasenia").Value.ToString();
            query = query.Replace("@contrasenia", contrasenia);
            query = query.Replace("@idUsuario", id.ToString());

            using (var sqlConnection = new SqlConnection(_sqlTestConnectionString))
            {
                if (sqlConnection == null) return null;
                sqlConnection.Open();


                var salida = await sqlConnection.QueryAsync(query, commandType: CommandType.Text);
                sqlConnection.Close();
                return Ok(salida);

            }
        }

    }
}
