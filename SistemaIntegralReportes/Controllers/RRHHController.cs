using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.Models;
using System.Data;

namespace SistemaIntegralReportes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RRHHController : ControllerBase
    {
        public HttpClient? _httpClient;
        private readonly IConfiguration _configuration;
        private string? _innovaConnectionString;
        private string? _sirConnectionString;
        private bool _connectionOK = false;
        private SqlConnection? _dbConnection = null;
        private SqlCommand? _command = null;
        private SqlDataReader? _reader = null;

        public RRHHController(HttpClient httpClient, IConfiguration configuration)
        {
            _innovaConnectionString = configuration.GetConnectionString("InnovaProduccion");
            _sirConnectionString = configuration.GetConnectionString("SqlTestConection");
            _connectionOK = _innovaConnectionString != null;
            _configuration = configuration;
        }

        [HttpGet("GetFuncionariosLogueados")]
        public IEnumerable<LogueoFuncionario> GetFuncionariosLogueados()
        {
            var query = _configuration.GetSection("FuncionariosLogueados").Value.ToString();

            using (var sqlConnection = new SqlConnection(_innovaConnectionString))
            {
                if (sqlConnection == null) return null;
                sqlConnection.Open();

                var salida = sqlConnection.Query<LogueoFuncionario>(query, commandType: CommandType.StoredProcedure);
                sqlConnection.Close();
                return salida;

            }
        }

        [HttpGet("GetHorarioFuncionario")]
        public IEnumerable<HorarioEmpleado> GetHorarioFuncionario(DateTime fecha, string numeroFunc)
        {
            var query = _configuration.GetSection("HorarioFuncionario").Value.ToString();
            query = query.Replace("@fechaDesde", fecha.ToString("yyyyMMdd"));
            query = query.Replace("@fechaHasta", fecha.AddDays(1).ToString("yyyyMMdd"));
            query = query.Replace("@numeroFunc", numeroFunc);

            using (var sqlConnection = new SqlConnection(_innovaConnectionString))
            {
                if (sqlConnection == null) return null;
                sqlConnection.Open();

                var salida = sqlConnection.Query<HorarioEmpleado>(query, commandType: CommandType.Text);
                sqlConnection.Close();
                return salida;

            }
        }

        [HttpGet("GetEmpleados")]
        public IEnumerable<Empleado> GetEmpleados()
        {
            var query = _configuration.GetSection("Empleados").Value.ToString();
            using (var sqlConnection = new SqlConnection(_innovaConnectionString))
            {
                if (sqlConnection == null) return null;
                sqlConnection.Open();

                var salida = sqlConnection.Query<Empleado>(query, commandType: CommandType.Text);
                sqlConnection.Close();
                return salida;

            }
        }

        [HttpGet("GetPadronFuncionarios")]
        public IEnumerable<PadronFuncionario> GetPadronFuncionarios()
        {
            var query = _configuration.GetSection("PadronFuncionarios").Value.ToString();
            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return null;
                try
                {
                    connection.Open();
                    var padron = connection.Query<PadronFuncionario>(query, commandType: CommandType.Text);
                    connection.Close();
                    return padron;
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpPost("ActualizarPadronFuncionarios")]
        public void ActualizarPadronFuncionarios([FromBody] List<PadronFuncionario> padronFuncionarios) {
            if (padronFuncionarios == null || padronFuncionarios.Count == 0) Console.WriteLine("No se proporcionaron los datos de los funcionarios");

            using(var connection = new SqlConnection(_sirConnectionString))
            {
                try
                {
                    connection.Open();
                    var queryDelete = _configuration.GetSection("EliminarPadronFuncionarios").Value.ToString();
                    using(var cmd = new SqlCommand(queryDelete, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                    connection.Open();

                    foreach (var funcionario in padronFuncionarios)
                    {
                        var query = _configuration.GetSection("InsertarPadronFuncionarios").Value.ToString();
                        using (var command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@nroFunc", funcionario.NroFuncionario);
                            command.Parameters.AddWithValue("@apellidos", funcionario.Apellidos);
                            command.Parameters.AddWithValue("@nombres", funcionario.Nombres);
                            command.Parameters.AddWithValue("@sector", funcionario.Sector);
                            command.Parameters.AddWithValue("@tipoRemuneracion", funcionario.TipoRemuneracion);
                            command.Parameters.AddWithValue("@horasTrabajadas", funcionario.HorasTrabajadas);
                            command.Parameters.AddWithValue("@diasTrabajados", funcionario.DiasTrabajados);

                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                  Console.WriteLine($"Error al insertar empleados: {ex.Message}");
                }
            }
        }

        [HttpGet("GetRegimen")]
        public IEnumerable<Regimen> GetRegimens()
        {
            var query = _configuration.GetSection("Regimen").Value.ToString();
            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return null;
                try
                {
                    connection.Open();
                    var regimens = connection.Query<Regimen>(query, commandType: CommandType.Text);
                    connection.Close();
                    return regimens;
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpGet("GetConfHoras")]
        public IEnumerable<ConfHoras> GetConfHoras()
        {
            var query = _configuration.GetSection("ConfHoras").Value.ToString();
            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return null;
                try
                {
                    connection.Open();
                    var confHoras = connection.Query<ConfHoras>(query, commandType: CommandType.Text);
                    connection.Close();
                    return confHoras;
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpGet("GetFuncionariosHorarioDesfasado")]
        public IEnumerable<FuncioarioHorarioDesfasado> GetFuncioariosHorarioDesfasado()
        {
            var query = _configuration.GetSection("HorariosDesfasados").Value.ToString();
            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return null;
                try
                {
                    connection.Open();
                    var horariosDesfasados = connection.Query<FuncioarioHorarioDesfasado>(query, commandType: CommandType.Text);
                    connection.Close();
                    return horariosDesfasados;
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpPost("ActualizarHorariosDesfasados")]
        public void ActualizarHorariosDesfasados([FromBody] List<FuncioarioHorarioDesfasado> funcionarios)
        {
            if (funcionarios == null || funcionarios.Count == 0) Console.WriteLine("No se proporcionaron los datos de los funcionarios");

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                try
                {
                    connection.Open();
                    var queryDelete = _configuration.GetSection("EliminarHorariosDesfasados").Value.ToString();
                    using (var cmd = new SqlCommand(queryDelete, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                    connection.Open();

                    foreach (var funcionario in funcionarios)
                    {
                        var query = _configuration.GetSection("InsertarHorariosDesfasados").Value.ToString();
                        using (var command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@nroFunc", funcionario.nroFuncionario);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al insertar empleados: {ex.Message}");
                }
            }
        }

        [HttpGet("LoginHistoricoFuncionariosMarel")]
        public IEnumerable<LoginHistorico> GetLoginHistoricoFuncionariosMarel(string fechaDesde, string fechaHasta)
        {
            var query = _configuration.GetSection("DwHistoricoFuncionariosLogueados").Value.ToString();
            query = query.Replace("@fechaDesde", fechaDesde);
            query = query.Replace("@fechaHasta", fechaHasta);

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return null;
                try
                {
                    connection.Open();
                    var logins = connection.Query<LoginHistorico>(query, commandType: CommandType.Text);
                    connection.Close();
                    return logins;
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
