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
    public class DashboardDesosadoController : ControllerBase
    {
        public HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string? _innovaConnectionString;
        private string? _sirConnectionString;
        private bool _connectionOK = false;

        public DashboardDesosadoController(HttpClient httpClient, IConfiguration configuration)
        {

            _innovaConnectionString = configuration.GetConnectionString("InnovaProduccion");
            _sirConnectionString = configuration.GetConnectionString("SqlTestConection");
            _connectionOK = _innovaConnectionString != null;
            _configuration = configuration;
        }

        #region Métodos síncronos
        [HttpGet("GetDetalleEntrada")]
        public IEnumerable<DetalleEntrada> GetDetalleEntrada()
        {
            DateTime prday = DateTime.Today;
            DateTime fechaDesde = new DateTime(prday.Year, prday.Month, prday.Day);
            DateTime fechaHasta = new DateTime(prday.Year, prday.Month, prday.Day);

            var query = _configuration.GetSection("DetalleEntrada").Value.ToString();
            query = query.Replace("@fechaDesde", fechaDesde.ToString("yyyy-MM-dd HH:mm:ss")).Replace("/", "-");
            query = query.Replace("@fechaHasta", fechaHasta.ToString("yyyy-MM-dd HH:mm:ss")).Replace("/", "-");
            
            using (var sqlConnection = new SqlConnection(_innovaConnectionString))
            {
                if (sqlConnection == null) return null;

                try
                {
                    sqlConnection.Open();

                    var entrada = sqlConnection.Query<DetalleEntrada>(query, commandType: CommandType.Text);
                    sqlConnection.Close();
                    return entrada;
                }
                catch (Exception e)
                {
                    if(sqlConnection != null)
                        sqlConnection.Close();

                    throw new Exception(e.Message);
                }


            }

        }

        [HttpGet("SIRGetDetalleEntrada")]
        public IEnumerable<DetalleEntrada> SIRGetDetalleEntrada()
        {
            var query = _configuration.GetSection("DWDetalleEntrada").Value.ToString();
           
            using (var sqlConnection = new SqlConnection(_sirConnectionString))
            {
                if (sqlConnection == null) return null;

                try
                {
                    sqlConnection.Open();

                    var entrada = sqlConnection.Query<DetalleEntrada>(query, commandType: CommandType.Text);
                    sqlConnection.Close();
                    return entrada;
                }
                catch (Exception e)
                {
                    if (sqlConnection != null)
                        sqlConnection.Close();

                    throw new Exception(e.Message);
                }


            }

        }

        [HttpPost("ActualizarDetalleEntrada")]
        public void ActualizarDetalleEntrada([FromBody] List<DetalleEntrada> lotesEntrada)
        {
            if (lotesEntrada == null) throw new ArgumentNullException("No hay datos de entrada");
            
            using (var connection = new SqlConnection(_sirConnectionString))
            {
                try
                {
                    connection.Open();
                    var queryDelete = _configuration.GetSection("DWDeleteDetalleEntrada").Value.ToString();
                    try
                    {
                        using (var cmd = new SqlCommand(queryDelete, connection))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception)
                    {
                        connection.Close();
                        throw;
                    }

                    try
                    {
                        foreach (var loteEntrada in lotesEntrada)
                        {
                            var query = _configuration.GetSection("DWUptadeDetalleEntrada").Value.ToString();
                            using (var command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@tipoEntrada", loteEntrada.TipoEntrada);
                                command.Parameters.AddWithValue("@codigo", loteEntrada.Codigo);
                                command.Parameters.AddWithValue("@producto", loteEntrada.Producto);
                                command.Parameters.AddWithValue("@cuartos", loteEntrada.Cuartos);
                                command.Parameters.AddWithValue("@pesoCuartos", loteEntrada.PesoCuartos);
                                command.Parameters.AddWithValue("@promedio", loteEntrada.Promedio);
                                command.Parameters.AddWithValue("@horaPrimerCuarto", loteEntrada.HoraPrimerCuarto);
                                command.Parameters.AddWithValue("@horaUltimoCuarto", loteEntrada.HoraUltimoCuarto);

                                command.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        connection.Close();
                        throw;
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpGet("DetalleCharqueadores")]
        public IEnumerable<IndicadorCharqueadores> GetDetalleCharqueadores() 
        {
            DateTime prday = DateTime.Today;
            DateTime fechaD = new DateTime(prday.Year, prday.Month, prday.Day);
            DateTime fechaH = new DateTime(prday.Year, prday.Month, prday.Day);
            DateTime fechaDesde = fechaD.AddMinutes(1);
            DateTime fechaHasta = fechaH.AddHours(23);

            var query = _configuration.GetSection("DetalleCharqueadores").Value.ToString();
            query = query.Replace("@fechaDesde", fechaDesde.ToString("yyyy-MM-dd HH:mm:ss")).Replace("/", "-");
            query = query.Replace("@fechaHasta", fechaHasta.ToString("yyyy-MM-dd HH:mm:ss")).Replace("/", "-");

            using (var sqlConnection = new SqlConnection(_innovaConnectionString))
            {
                if (sqlConnection == null) return null;

                try
                {
                    sqlConnection.Open();

                    var detalle = sqlConnection.Query<IndicadorCharqueadores>(query, commandType: CommandType.Text);
                    sqlConnection.Close();
                    return detalle;
                }
                catch (Exception e)
                {
                    if (sqlConnection != null)
                        sqlConnection.Close();

                    throw new Exception(e.Message);
                }
            }
        }

        [HttpGet("SIRDetalleCharqueadores")]
        public IEnumerable<IndicadorCharqueadores> SIRGetDetalleCharqueadores()
        {
            var query = _configuration.GetSection("DWDetalleCharqueadores").Value.ToString();

            using (var sqlConnection = new SqlConnection(_sirConnectionString))
            {
                if (sqlConnection == null) return null;

                try
                {
                    sqlConnection.Open();

                    var detalle = sqlConnection.Query<IndicadorCharqueadores>(query, commandType: CommandType.Text);
                    sqlConnection.Close();
                    return detalle;
                }
                catch (Exception e)
                {
                    if (sqlConnection != null)
                        sqlConnection.Close();

                    throw new Exception(e.Message);
                }
            }
        }

        [HttpPost("ActualizarDetalleCharqueadores")]
        public void ActualizarDetalleCharqueadores([FromBody] List<IndicadorCharqueadores> charqueadores)
        {
            if (charqueadores == null) throw new ArgumentNullException("No hay datos de charqueadores");

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                try
                {
                    connection.Open();
                    var queryDelete = _configuration.GetSection("DWDeleteDetalleCharqueadores").Value.ToString();
                    try
                    {
                        using (var cmd = new SqlCommand(queryDelete, connection))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception)
                    {
                        connection.Close();
                        throw;
                    }

                    try
                    {
                        foreach (var charqueador in charqueadores)
                        {
                            var query = _configuration.GetSection("DWUptadeDetalleCharqueadores").Value.ToString();
                            using (var command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@linea", charqueador.Linea);
                                command.Parameters.AddWithValue("@nombreEstacion", charqueador.NombreEstacion);
                                command.Parameters.AddWithValue("@idEstacion", charqueador.IdEstacion);
                                command.Parameters.AddWithValue("@charqNum", charqueador.CharqNum);
                                command.Parameters.AddWithValue("@charqueador", charqueador.Charqueador);
                                command.Parameters.AddWithValue("@cortesRecibidos", charqueador.CortesRecibidos);
                                command.Parameters.AddWithValue("@cortesEnviados", charqueador.CortesEnviados);
                                command.Parameters.AddWithValue("@kgRecibidos", charqueador.KgRecibidos);
                                command.Parameters.AddWithValue("@kgEnviados", charqueador.KgEnviados);
                                command.Parameters.AddWithValue("@porcRendimiento", charqueador.PorcRendimiento);
                                command.Parameters.AddWithValue("@procRendPromedio", charqueador.ProcRendPromedio);
                                command.Parameters.AddWithValue("@promedioKilosSalidaCharqueador", charqueador.PromedioKilosSalidaCharqueador);

                                command.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        connection.Close();
                        throw;
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpGet("GetDetalleHueseros")]
        public IEnumerable<IndicadorHueseros> GetDetalleHueseros()
        {
            DateTime prday = DateTime.Today;
            DateTime fechaD = new DateTime(prday.Year, prday.Month, prday.Day);
            DateTime fechaH = new DateTime(prday.Year, prday.Month, prday.Day);
            DateTime fechaDesde = fechaD.AddMinutes(1);
            DateTime fechaHasta = fechaH.AddHours(23);

            var query = _configuration.GetSection("DetalleHueseros").Value.ToString();
            query = query.Replace("@fechaDesde", fechaDesde.ToString("yyyy-MM-dd HH:mm:ss")).Replace("/", "-");
            query = query.Replace("@fechaHasta", fechaHasta.ToString("yyyy-MM-dd HH:mm:ss")).Replace("/", "-");

            using (var sqlConnection = new SqlConnection(_innovaConnectionString))
            {
                if (sqlConnection == null) return null;

                try
                {
                    sqlConnection.Open();

                    var detalle = sqlConnection.Query<IndicadorHueseros>(query, commandType: CommandType.Text);
                    sqlConnection.Close();
                    return detalle;
                }
                catch (Exception e)
                {
                    if (sqlConnection != null)
                        sqlConnection.Close();

                    throw new Exception(e.Message);
                }
            }
        }

        [HttpGet("SIRGetDetalleHueseros")]
        public IEnumerable<IndicadorHueseros> SIRGetDetalleHueseros()
        {
            var query = _configuration.GetSection("DWDetalleHueseros").Value.ToString();

            using (var sqlConnection = new SqlConnection(_sirConnectionString))
            {
                if (sqlConnection == null) return null;

                try
                {
                    sqlConnection.Open();

                    var detalle = sqlConnection.Query<IndicadorHueseros>(query, commandType: CommandType.Text);
                    sqlConnection.Close();
                    return detalle;
                }
                catch (Exception e)
                {
                    if (sqlConnection != null)
                        sqlConnection.Close();

                    throw new Exception(e.Message);
                }
            }
        }

        [HttpPost("ActualizarDetalleHueseros")]
        public void ActualizarDetalleHueseros([FromBody] List<IndicadorHueseros> hueseros)
        {
            if (hueseros == null) throw new ArgumentNullException("No hay datos de hueseros");

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                try
                {
                    connection.Open();
                    var queryDelete = _configuration.GetSection("DWDeleteDetalleHueseros").Value.ToString();
                    try
                    {
                        using (var cmd = new SqlCommand(queryDelete, connection))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception)
                    {
                        connection.Close();
                        throw;
                    }

                    try
                    {
                        foreach (var huesero in hueseros)
                        {
                            var query = _configuration.GetSection("DWUptadeDetalleHueseros").Value.ToString();
                            using (var command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@linea", huesero.Linea);
                                command.Parameters.AddWithValue("@idEstacion", huesero.Linea);
                                command.Parameters.AddWithValue("@nombreEstación", huesero.Linea);
                                command.Parameters.AddWithValue("@hueseroCod", huesero.Linea);
                                command.Parameters.AddWithValue("@huesero", huesero.Linea);
                                command.Parameters.AddWithValue("@cuartos", huesero.Linea);
                                command.Parameters.AddWithValue("@kgRecibidos", huesero.Linea);
                                command.Parameters.AddWithValue("@kgEnviados", huesero.Linea);
                                command.Parameters.AddWithValue("@rend", huesero.Linea);

                                command.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        connection.Close();
                        throw;
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpGet("GetDetalleEmpaque")]
        public IEnumerable<IndicadorEmpaque> GetDetalleEmpaque()
        {
            DateTime prday = DateTime.Today;
            DateTime fechaD = new DateTime(prday.Year, prday.Month, prday.Day);
            DateTime fechaH = new DateTime(prday.Year, prday.Month, prday.Day);
            DateTime fechaDesde = fechaD.AddMinutes(1);
            DateTime fechaHasta = fechaH.AddHours(23);

            var query = _configuration.GetSection("DetalleEmpaque").Value.ToString();
            query = query.Replace("@fechaDesde", fechaDesde.ToString("yyyy-MM-dd HH:mm:ss")).Replace("/", "-");
            query = query.Replace("@fechaHasta", fechaHasta.ToString("yyyy-MM-dd HH:mm:ss")).Replace("/", "-");

            using (var sqlConnection = new SqlConnection(_innovaConnectionString))
            {
                if (sqlConnection == null) return null;

                try
                {
                    sqlConnection.Open();

                    var detalle = sqlConnection.Query<IndicadorEmpaque>(query, commandType: CommandType.Text);
                    sqlConnection.Close();
                    return detalle;
                }
                catch (Exception e)
                {
                    if (sqlConnection != null)
                        sqlConnection.Close();

                    throw new Exception(e.Message);
                }
            }
        }

        [HttpGet("SIRGetDetalleEmpaque")]
        public IEnumerable<IndicadorEmpaque> SIRGetDetalleEmpaque()
        {
            var query = _configuration.GetSection("DWDetalleEmpaquePrimario").Value.ToString();

            using (var sqlConnection = new SqlConnection(_sirConnectionString))
            {
                if (sqlConnection == null) return null;

                try
                {
                    sqlConnection.Open();

                    var detalle = sqlConnection.Query<IndicadorEmpaque>(query, commandType: CommandType.Text);
                    sqlConnection.Close();
                    return detalle;
                }
                catch (Exception e)
                {
                    if (sqlConnection != null)
                        sqlConnection.Close();

                    throw new Exception(e.Message);
                }
            }
        }

        [HttpPost("ActualizarDetalleEmpaque")]
        public void ActualizarDetalleEmpaque([FromBody] List<IndicadorEmpaque> empaque)
        {
            if (empaque == null) throw new ArgumentNullException("No hay datos de empaque");

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                try
                {
                    connection.Open();
                    var queryDelete = _configuration.GetSection("DWDeleteDetalleEmpaquePrimario").Value.ToString();
                    try
                    {
                        using (var cmd = new SqlCommand(queryDelete, connection))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception)
                    {
                        connection.Close();
                        throw;
                    }

                    try
                    {
                        foreach (var pack in empaque)
                        {
                            var query = _configuration.GetSection("DWUptadeDetalleEmpaquePrimario").Value.ToString();
                            using (var command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@station", pack.Station);
                                command.Parameters.AddWithValue("@puesto", pack.Puesto);
                                command.Parameters.AddWithValue("@cortes", pack.Cortes);
                                command.Parameters.AddWithValue("@peso", pack.Peso);

                                command.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        connection.Close();
                        throw;
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpGet("GetRefreshTime")]
        public string GetRefreshTime()
        {
            return _configuration.GetSection("RefreshTimeInterval").Value.ToString();

        }
        #endregion

        #region Métodos asíncronos
        [HttpGet("GetDetalleEntradaAsync")]
        public async Task<IEnumerable<DetalleEntrada>> GetDetalleEntradaAsync()
        {
            DateTime prday = DateTime.Today;
            DateTime fechaDesde = new DateTime(prday.Year, prday.Month, prday.Day);
            DateTime fechaHasta = new DateTime(prday.Year, prday.Month, prday.Day);
            fechaDesde.AddHours(23);

            var query = _configuration.GetSection("DetalleEntrada").Value.ToString();
            query = query.Replace("@fechaDesde", fechaDesde.ToString("yyyy-MM-dd HH:mm:ss")).Replace("/", "-");
            query = query.Replace("@fechaHasta", fechaHasta.ToString("yyyy-MM-dd HH:mm:ss")).Replace("/", "-");

            using (var sqlConnection = new SqlConnection(_innovaConnectionString))
            {
                if (sqlConnection == null) return null;

                try
                {
                    sqlConnection.Open();

                    var entrada = await sqlConnection.QueryAsync<DetalleEntrada>(query, commandType: CommandType.Text);
                    sqlConnection.Close();
                    return entrada;
                }
                catch (Exception e)
                {
                    if (sqlConnection != null)
                        sqlConnection.Close();

                    throw new Exception(e.Message);
                }
            }

        }

        [HttpGet("SIRGetDetalleEntradaAsync")]
        public async Task<IEnumerable<DetalleEntrada>> SIRGetDetalleEntradaAsync()
        {
            var query = _configuration.GetSection("DWDetalleEntrada").Value.ToString();
           
            using (var sqlConnection = new SqlConnection(_sirConnectionString))
            {
                if (sqlConnection == null) return null;

                try
                {
                    sqlConnection.Open();

                    var entrada = await sqlConnection.QueryAsync<DetalleEntrada>(query, commandType: CommandType.Text);
                    sqlConnection.Close();
                    return entrada;
                }
                catch (Exception e)
                {
                    if (sqlConnection != null)
                        sqlConnection.Close();

                    throw new Exception(e.Message);
                }
            }

        }

        [HttpPost("ActualizarDetalleEntradaAsync")]
        public async void ActualizarDetalleEntradaAsync([FromBody] List<DetalleEntrada> lotesEntrada)
        {
            if (lotesEntrada == null) throw new ArgumentNullException("No hay datos de entrada");

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                try
                {
                    connection.Open();
                    var queryDelete = _configuration.GetSection("DWDeleteDetalleEntrada").Value.ToString();
                    try
                    {
                        using (var cmd = new SqlCommand(queryDelete, connection))
                        {
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                    catch (Exception)
                    {
                        connection.Close();
                        throw;
                    }

                    try
                    {
                        foreach (var loteEntrada in lotesEntrada)
                        {
                            var query = _configuration.GetSection("DWUptadeDetalleEntrada").Value.ToString();
                            using (var command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@tipoEntrada", loteEntrada.TipoEntrada);
                                command.Parameters.AddWithValue("@codigo", loteEntrada.Codigo);
                                command.Parameters.AddWithValue("@producto", loteEntrada.Producto);
                                command.Parameters.AddWithValue("@cuartos", loteEntrada.Cuartos);
                                command.Parameters.AddWithValue("@pesoCuartos", loteEntrada.PesoCuartos);
                                command.Parameters.AddWithValue("@promedio", loteEntrada.Promedio);
                                command.Parameters.AddWithValue("@horaPrimerCuarto", loteEntrada.HoraPrimerCuarto);
                                command.Parameters.AddWithValue("@horaUltimoCuarto", loteEntrada.HoraUltimoCuarto);

                                await command.ExecuteNonQueryAsync();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        connection.Close();
                        throw;
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpGet("DetalleCharqueadoresAsync")]
        public async Task<IEnumerable<IndicadorCharqueadores>> GetDetalleCharqueadoresAsync()
        {
            DateTime prday = DateTime.Today;
            DateTime fechaD = new DateTime(prday.Year, prday.Month, prday.Day);
            DateTime fechaH = new DateTime(prday.Year, prday.Month, prday.Day);
            DateTime fechaDesde = fechaD.AddMinutes(1);
            DateTime fechaHasta = fechaH.AddHours(23);

            var query = _configuration.GetSection("DetalleCharqueadores").Value.ToString();
            query = query.Replace("@fechaDesde", fechaDesde.ToString("yyyy-MM-dd HH:mm:ss")).Replace("/", "-");
            query = query.Replace("@fechaHasta", fechaHasta.ToString("yyyy-MM-dd HH:mm:ss")).Replace("/", "-");

            using (var sqlConnection = new SqlConnection(_innovaConnectionString))
            {
                if (sqlConnection == null) return null;

                try
                {
                    sqlConnection.Open();

                    var detalle = await sqlConnection.QueryAsync<IndicadorCharqueadores>(query, commandType: CommandType.Text);
                    sqlConnection.Close();
                    return detalle;
                }
                catch (Exception e)
                {
                    if (sqlConnection != null)
                        sqlConnection.Close();

                    throw new Exception(e.Message);
                }
            }
        }

        [HttpGet("SIRDetalleCharqueadoresAsync")]
        public async Task<IEnumerable<IndicadorCharqueadores>> SIRGetDetalleCharqueadoresAsync()
        {
            var query = _configuration.GetSection("DWDetalleCharqueadores").Value.ToString();
          
            using (var sqlConnection = new SqlConnection(_sirConnectionString))
            {
                if (sqlConnection == null) return null;

                try
                {
                    sqlConnection.Open();

                    var detalle = await sqlConnection.QueryAsync<IndicadorCharqueadores>(query, commandType: CommandType.Text);
                    sqlConnection.Close();
                    return detalle;
                }
                catch (Exception e)
                {
                    if (sqlConnection != null)
                        sqlConnection.Close();

                    throw new Exception(e.Message);
                }
            }
        }

        [HttpPost("ActualizarDetalleCharqueadoresAsync")]
        public async void ActualizarDetalleCharqueadoresAsync([FromBody] List<IndicadorCharqueadores> charqueadores)
        {
            if (charqueadores == null) throw new ArgumentNullException("No hay datos de charqueadores");

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                try
                {
                    connection.Open();
                    var queryDelete = _configuration.GetSection("DWDeleteDetalleCharqueadores").Value.ToString();
                    try
                    {
                        using (var cmd = new SqlCommand(queryDelete, connection))
                        {
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                    catch (Exception)
                    {
                        connection.Close();
                        throw;
                    }

                    try
                    {
                        foreach (var charqueador in charqueadores)
                        {
                            var query = _configuration.GetSection("DWUptadeDetalleCharqueadores").Value.ToString();
                            using (var command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@linea", charqueador.Linea ?? "null");
                                command.Parameters.AddWithValue("@nombreEstacion", charqueador.NombreEstacion ?? "null");
                                command.Parameters.AddWithValue("@idEstacion", charqueador.IdEstacion);
                                command.Parameters.AddWithValue("@charqNum", charqueador.CharqNum);
                                command.Parameters.AddWithValue("@charqueador", charqueador.Charqueador);
                                command.Parameters.AddWithValue("@cortesRecibidos", charqueador.CortesRecibidos);
                                command.Parameters.AddWithValue("@cortesEnviados", charqueador.CortesEnviados);
                                command.Parameters.AddWithValue("@kgRecibidos", charqueador.KgRecibidos);
                                command.Parameters.AddWithValue("@kgEnviados", charqueador.KgEnviados);
                                command.Parameters.AddWithValue("@porcRendimiento", charqueador.PorcRendimiento);
                                command.Parameters.AddWithValue("@procRendPromedio", charqueador.ProcRendPromedio);
                                command.Parameters.AddWithValue("@promedioKilosSalidaCharqueador", charqueador.PromedioKilosSalidaCharqueador);

                                await command.ExecuteNonQueryAsync();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        connection.Close();
                        throw;
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpGet("GetDetalleHueserosAsync")]
        public async Task<IEnumerable<IndicadorHueseros>> GetDetalleHueserosAsync()
        {
            DateTime prday = DateTime.Today;
            DateTime fechaD = new DateTime(prday.Year, prday.Month, prday.Day);
            DateTime fechaH = new DateTime(prday.Year, prday.Month, prday.Day);
            DateTime fechaDesde = fechaD.AddMinutes(1);
            DateTime fechaHasta = fechaH.AddHours(23);

            var query = _configuration.GetSection("DetalleHueseros").Value.ToString();
            query = query.Replace("@fechaDesde", fechaDesde.ToString("yyyy-MM-dd HH:mm:ss")).Replace("/", "-");
            query = query.Replace("@fechaHasta", fechaHasta.ToString("yyyy-MM-dd HH:mm:ss")).Replace("/", "-");

            using (var sqlConnection = new SqlConnection(_innovaConnectionString))
            {
                if (sqlConnection == null) return null;

                try
                {
                    sqlConnection.Open();

                    var detalle = await sqlConnection.QueryAsync<IndicadorHueseros>(query, commandType: CommandType.Text);
                    sqlConnection.Close();
                    return detalle;
                }
                catch (Exception e)
                {
                    if (sqlConnection != null)
                        sqlConnection.Close();

                    throw new Exception(e.Message);
                }
            }
        }

        [HttpGet("SIRGetDetalleHueserosAsync")]
        public async Task<IEnumerable<IndicadorHueseros>> SIRGetDetalleHueserosAsync()
        {
            var query = _configuration.GetSection("DWDetalleHueseros").Value.ToString();
            using (var sqlConnection = new SqlConnection(_sirConnectionString))
            {
                if (sqlConnection == null) return null;

                try
                {
                    sqlConnection.Open();

                    var detalle = await sqlConnection.QueryAsync<IndicadorHueseros>(query, commandType: CommandType.Text);
                    sqlConnection.Close();
                    return detalle;
                }
                catch (Exception e)
                {
                    if (sqlConnection != null)
                        sqlConnection.Close();

                    throw new Exception(e.Message);
                }
            }
        }

        [HttpPost("ActualizarDetalleHueserosAsync")]
        public async void ActualizarDetalleHueserosAsync([FromBody] List<IndicadorHueseros> hueseros)
        {
            if (hueseros == null) throw new ArgumentNullException("No hay datos de hueseros");

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                try
                {
                    connection.Open();
                    var queryDelete = _configuration.GetSection("DWDeleteDetalleHueseros").Value.ToString();
                    try
                    {
                        using (var cmd = new SqlCommand(queryDelete, connection))
                        {
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                    catch (Exception)
                    {
                        connection.Close();
                        throw;
                    }

                    try
                    {
                        foreach (var huesero in hueseros)
                        {
                            var query = _configuration.GetSection("DWUptadeDetalleHueseros").Value.ToString();
                            using (var command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@linea", huesero.Linea);
                                command.Parameters.AddWithValue("@idEstacion", huesero.IdEstacion);
                                command.Parameters.AddWithValue("@nombreEstación", huesero.NombreEstación);
                                command.Parameters.AddWithValue("@hueseroCod", huesero.HueseroCod);
                                command.Parameters.AddWithValue("@huesero", huesero.Huesero);
                                command.Parameters.AddWithValue("@cuartos", huesero.Cuartos);
                                command.Parameters.AddWithValue("@kgRecibidos", huesero.KgRecibidos);
                                command.Parameters.AddWithValue("@kgEnviados", huesero.KgEnviados);
                                command.Parameters.AddWithValue("@rend", huesero.Rend);

                                await command.ExecuteNonQueryAsync();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        connection.Close();
                        throw;
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpGet("GetDetalleEmpaqueAsync")]
        public async Task<IEnumerable<IndicadorEmpaque>> GetDetalleEmpaqueAsync()
        {
            DateTime prday = DateTime.Today;
            DateTime fechaD = new DateTime(prday.Year, prday.Month, prday.Day);
            DateTime fechaH = new DateTime(prday.Year, prday.Month, prday.Day);
            DateTime fechaDesde = fechaD.AddMinutes(1);
            DateTime fechaHasta = fechaH.AddHours(23);

            var query = _configuration.GetSection("DetalleEmpaque").Value.ToString();
            query = query.Replace("@fechaDesde", fechaDesde.ToString("yyyy-MM-dd HH:mm:ss")).Replace("/", "-");
            query = query.Replace("@fechaHasta", fechaHasta.ToString("yyyy-MM-dd HH:mm:ss")).Replace("/", "-");

            using (var sqlConnection = new SqlConnection(_innovaConnectionString))
            {
                if (sqlConnection == null) return null;

                try
                {
                    sqlConnection.Open();

                    var detalle = await sqlConnection.QueryAsync<IndicadorEmpaque>(query, commandType: CommandType.Text);
                    sqlConnection.Close();
                    return detalle;
                }
                catch (Exception e)
                {
                    if (sqlConnection != null)
                        sqlConnection.Close();

                    throw new Exception(e.Message);
                }
            }
        }

        [HttpGet("SIRGetDetalleEmpaqueAsync")]
        public async Task<IEnumerable<IndicadorEmpaque>> SIRGetDetalleEmpaqueAsync()
        {
            var query = _configuration.GetSection("DWDetalleEmpaquePrimario").Value.ToString();

            using (var sqlConnection = new SqlConnection(_sirConnectionString))
            {
                if (sqlConnection == null) return null;

                try
                {
                    sqlConnection.Open();

                    var detalle = await sqlConnection.QueryAsync<IndicadorEmpaque>(query, commandType: CommandType.Text);
                    sqlConnection.Close();
                    return detalle;
                }
                catch (Exception e)
                {
                    if (sqlConnection != null)
                        sqlConnection.Close();

                    throw new Exception(e.Message);
                }
            }
        }

        [HttpPost("ActualizarDetalleEmpaqueAsync")]
        public async void ActualizarDetalleEmpaqueAsync([FromBody] List<IndicadorEmpaque> empaque)
        {
            if (empaque == null) throw new ArgumentNullException("No hay datos de empaque");

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                try
                {
                    connection.Open();
                    var queryDelete = _configuration.GetSection("DWDeleteDetalleEmpaquePrimario").Value.ToString();
                    try
                    {
                        using (var cmd = new SqlCommand(queryDelete, connection))
                        {
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                    catch (Exception)
                    {
                        connection.Close();
                        throw;
                    }

                    try
                    {
                        foreach (var pack in empaque)
                        {
                            var query = _configuration.GetSection("DWUptadeDetalleEmpaquePrimario").Value.ToString();
                            using (var command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@station", pack.Station);
                                command.Parameters.AddWithValue("@puesto", pack.Puesto);
                                command.Parameters.AddWithValue("@cortes", pack.Cortes);
                                command.Parameters.AddWithValue("@peso", pack.Peso);

                                await command.ExecuteNonQueryAsync();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        connection.Close();
                        throw;
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        #endregion


    }
}
