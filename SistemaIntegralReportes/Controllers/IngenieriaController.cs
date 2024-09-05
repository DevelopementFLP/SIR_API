using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.Models;
using Dapper;

namespace SistemaIntegralReportes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngenieriaController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public HttpClient _httpClient;
        private string? _innovaConnectionString;
        private string? _sirConnectionString;
        private bool _connectionOK = false;

        public IngenieriaController(IConfiguration configuration) 
        {
            _innovaConnectionString = configuration.GetConnectionString("InnovaProduccion");
            _sirConnectionString = configuration.GetConnectionString("SqlTestConection");
            _connectionOK = _innovaConnectionString != null;
            _configuration = configuration;
        }

        #region Métodos asíncronos
        [HttpGet("GetDatosScadaAsync")]
        public async Task<IEnumerable<Scada>> GetDatosScadaAsync()
        {
            var query = _configuration.GetSection("Ingenieria:GetDatosScada").Value.ToString();

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return null;
                try
                {
                    connection.Open();
                  
                    var data = await connection.QueryAsync<Scada>(query, commandType: System.Data.CommandType.Text);
                    connection.Close();
                    return data;
                }
                catch (Exception e)
                {
                    if (connection != null)
                        connection.Close();
                    throw new Exception(e.Message);
                }
            }
        }

        [HttpGet("GetDatosScadaPorDispositivoAsync")]
        public async Task<IEnumerable<Scada>> GetDatosScadaPorDispositivoAsync(int idTipoDispositivo)
        {
            var query = _configuration.GetSection("Ingenieria:GetDatosScadaPorDispositivo").Value.ToString();

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return null;
                try
                {
                    connection.Open();
                    query = query.Replace("@idTipoDispositivo", idTipoDispositivo.ToString());
                    var data = await connection.QueryAsync<Scada>(query, commandType: System.Data.CommandType.Text);
                    connection.Close();
                    return data;
                }
                catch (Exception e)
                {
                    if (connection != null)
                        connection.Close();
                    throw new Exception(e.Message);
                }
            }
        }


        [HttpGet("GetDatosScadaPorUbicacionAsync")]
        public async Task<IEnumerable<Scada>> GetDatosScadaPorUbicacionAsync(int idUbicacion)
        {
            var query = _configuration.GetSection("Ingenieria:GetDatosScadaPorUbicacion").Value.ToString();

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return null;
                try
                {
                    connection.Open();
                    query = query.Replace("@idUbicacion", idUbicacion.ToString());
                    var data = await connection.QueryAsync<Scada>(query, commandType: System.Data.CommandType.Text);
                    connection.Close();
                    return data;
                }
                catch (Exception e)
                {
                    if (connection != null)
                        connection.Close();
                    throw new Exception(e.Message);
                }
            }
        }

        [HttpGet("GetDatosScadaPorDispositivoUbicacionAsync")]
        public async Task<IEnumerable<Scada>> GetDatosScadaPorDispositivoUbicacionAsync(int idTipoDispositivo, int idUbicacion)
        {
            var query = _configuration.GetSection("Ingenieria:GetDatosScadaPorDispositivoYUbicacion").Value.ToString();

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return null;
                try
                {
                    connection.Open();
                    query = query.Replace("@idTipoDispositivo", idTipoDispositivo.ToString()).Replace("@idUbicacion", idUbicacion.ToString());
                    var data = await connection.QueryAsync<Scada>(query, commandType: System.Data.CommandType.Text);
                    connection.Close();
                    return data;
                }
                catch (Exception e)
                {
                    if (connection != null)
                        connection.Close();
                    throw new Exception(e.Message);
                }
            }
        }

        [HttpGet("GetTiposDispositivosAsync")]
        public async Task<IEnumerable<TipoDispositivo>> GetTiposDispositivosAsync()
        {
            var query = _configuration.GetSection("Ingenieria:GetTiposDispositivoScada").Value.ToString();

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return null;
                try
                {
                    connection.Open();
                    var data = await connection.QueryAsync<TipoDispositivo>(query, commandType: System.Data.CommandType.Text);
                    connection.Close();
                    return data;
                }
                catch (Exception e)
                {
                    if (connection != null)
                        connection.Close();
                    throw new Exception(e.Message);
                }
            }
        }


        [HttpGet("GetUbicacionesAsync")]
        public async Task<IEnumerable<Ubicacion>> GetUbicacionesAsync()
        {
            var query = _configuration.GetSection("Ingenieria:GetUbicacionDispositivosScada").Value.ToString();

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return null;
                try
                {
                    connection.Open();
                    var data = await connection.QueryAsync<Ubicacion>(query, commandType: System.Data.CommandType.Text);
                    connection.Close();
                    return data;
                }
                catch (Exception e)
                {
                    if (connection != null)
                        connection.Close();
                    throw new Exception(e.Message);
                }
            }
        }

        [HttpGet("GetUnidadesMedidaAsync")]
        public async Task<IEnumerable<UnidadMedida>> GetUnidadesMedidaAsync()
        {
            var query = _configuration.GetSection("Ingenieria:GetUnidadesMedida").Value.ToString();

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return null;
                try
                {
                    connection.Open();

                    var unidades = await connection.QueryAsync<UnidadMedida>(query, commandType: System.Data.CommandType.Text);
                    connection.Close();
                    return unidades;
                }
                catch (Exception e)
                {
                    if (connection != null)
                        connection.Close();
                    throw new Exception(e.Message);
                }
            }
        }

        [HttpPost("InsertTipoDispositivoAsync")]
        public async Task InsertTipoDispositivoAsync([FromBody] List<TipoDispositivo> tipos)
        {
            using(var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return;
                try
                {
                    connection.Open();
                    foreach(TipoDispositivo tipo in tipos)
                    {
                        var query = _configuration.GetSection("Ingenieria:InsertTipoDispositivo").Value.ToString();
                        using(var command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@tipo", tipo.Nombre);
                            await command.ExecuteNonQueryAsync();
                        }
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    if(connection != null) connection.Close();
                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpPost("InsertUbicacionAsync")]
        public async Task InsertUbiccionAsync([FromBody] List<Ubicacion> ubicaciones)
        {
            using(var connection = new SqlConnection(_sirConnectionString))
            {
                if( connection == null) return;
                try
                {
                    connection.Open();
                    foreach(Ubicacion ubicacion in ubicaciones)
                    {
                        var query = _configuration.GetSection("Ingenieria:InsertUbicaion").Value.ToString();
                        using(var command = new SqlCommand(query,connection))
                        {
                            command.Parameters.AddWithValue("@idUP", ubicacion.IdUbicacionPadre);
                            command.Parameters.AddWithValue("@nombre", ubicacion.Nombre);
                            command.Parameters.AddWithValue("@desc", ubicacion.Descripcion);

                            await command.ExecuteNonQueryAsync();
                        }
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    if (connection != null) connection.Close();
                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpPost("InsertUnidadesMedidaAsync")]
        public async Task InsertUnidadesMedidaAsync([FromBody] List<UnidadMedida> unidades)
        {
            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return;
                try
                {
                    connection.Open();
                    foreach (UnidadMedida um in unidades)
                    {
                        var query = _configuration.GetSection("Ingenieria:InsertUnidadesMedida").Value.ToString();
                        using (var command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@codigo", um.Codigo);
                            command.Parameters.AddWithValue("@nombre", um.Nombre);

                            await command.ExecuteNonQueryAsync();
                        }
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    if (connection != null) connection.Close();
                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpPut("UpdateDatosScadaAsync")]
        public async Task<IActionResult> UpdateDatosScadaAsync([FromBody] List<Scada> datos)
        {
            if (datos == null)
            {
                return BadRequest("El objeto Scada datos no puede ser nulo");
            }

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null)
                {
                    return StatusCode(500, "Error interno del servidor");
                }

                try
                {
                    int rowsAffected = 0;

                    await connection.OpenAsync();

                    foreach (Scada dato in datos)
                    {
                        var query = _configuration.GetSection("Ingenieria:UpdateDatosScada").Value.ToString();

                        using (var command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@idT", dato.IdTipoDispositivo);
                            command.Parameters.AddWithValue("@idU", dato.IdUbicacion);
                            command.Parameters.AddWithValue("@idUM", dato.IdUnidadMedida);
                            command.Parameters.AddWithValue("@nombre", dato.Nombre);
                            command.Parameters.AddWithValue("@desc", dato.Descripcion);
                            command.Parameters.AddWithValue("@id", dato.Id);

                            rowsAffected += await command.ExecuteNonQueryAsync();

                        }
                    }

                    if (rowsAffected > 0)
                    {
                        return Ok( new { mensaje = "DatosScada actualizados correctamente" });
                    }
                    else
                    {
                        return NotFound(new { mensaje = "DatosScada no encontrados" });
                    }

                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }
        }

        [HttpPut("UpdateTipoDispositivoAsync")]
        public async Task<IActionResult> UpdateTipoDispositivoAsync([FromBody] List<TipoDispositivo> tipos)
        {
            if (tipos == null)
            {
                return BadRequest("El objeto TipoDispositivo no puede ser nulo");
            }

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null)
                {
                    return StatusCode(500, "Error interno del servidor");
                }

                try
                {
                    int rowsAffected = 0;

                    await connection.OpenAsync();
                    
                    foreach(TipoDispositivo tipo in tipos) { 
                        var query = _configuration.GetSection("Ingenieria:UpdateTipoDispositivo").Value.ToString();

                        using (var command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@id", tipo.IdTipo);
                            command.Parameters.AddWithValue("@nombre", tipo.Nombre);

                            rowsAffected += await command.ExecuteNonQueryAsync();
                        }
                    }

                    if (rowsAffected > 0)
                    {
                        return Ok( new { mensaje = "TiposDispositivo eliminados correctamente" });
                    }
                    else
                    {
                        return NotFound( new { mensaje = "TiposDispositivo no encontrados" });
                    }

                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }
        }


        [HttpPut("UpdateUbicacionAsync")]
        public async Task<IActionResult> UpdateUbicacionAsync([FromBody] List<Ubicacion> ubicaciones)
        {
            if (ubicaciones == null)
            {
                return BadRequest("Datos de ubicación no válidos");
            }

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null)
                {
                    return StatusCode(500, "Error interno del servidor");
                }

                try
                {
                    int rowsAffected = 0;

                    await connection.OpenAsync();

                    foreach(Ubicacion ubicacion in ubicaciones) { 
                        var query = _configuration.GetSection("Ingenieria:UpdateUbicacion").Value.ToString();

                        using (var command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@id", ubicacion.IdUbicacion);
                            command.Parameters.AddWithValue("@idUP", ubicacion.IdUbicacionPadre);
                            command.Parameters.AddWithValue("@nombre", ubicacion.Nombre);
                            command.Parameters.AddWithValue("@desc", ubicacion.Descripcion);

                            rowsAffected += await command.ExecuteNonQueryAsync();
                        }
                    }
                    if (rowsAffected > 0)
                    {
                        return Ok( new { mensaje = "Ubicaciones actualizadas correctamente" });
                    }
                    else
                    {
                        return NotFound(new { mensaje = "Ubicaciones no encontradas" });
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }
        }

        [HttpPut("UpdateUnidadesMedidaAsync")]
        public async Task<IActionResult> UpdateUnidadesMedidaAsync([FromBody] List<UnidadMedida> unidades)
        {
            if (unidades == null)
            {
                return BadRequest("El objeto UnidadMedida no puede ser nulo");
            }

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null)
                {
                    return StatusCode(500, "Error interno del servidor");
                }

                try
                {
                    int rowsAffected = 0;

                    await connection.OpenAsync();

                    foreach (UnidadMedida um in unidades)
                    {
                        var query = _configuration.GetSection("Ingenieria:UpdateUnidadesMedida").Value.ToString();

                        using (var command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@idUm", um.IdUnidadMedida);
                            command.Parameters.AddWithValue("@codigo", um.Codigo);
                            command.Parameters.AddWithValue("@nombre", um.Nombre);

                            rowsAffected += await command.ExecuteNonQueryAsync();
                        }
                    }

                    if (rowsAffected > 0)
                    {
                        return Ok(new { mensaje = "UnidadesMedida actualizadas correctamente" });
                    }
                    else
                    {
                        return NotFound(new { mensaje = "UnidadesMedida no encontrados" });
                    }

                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }
        }

        [HttpDelete("DeleteTipoDispositivoAsync")]
        public async Task DeleteTipoDispositivoAsync([FromBody] List<TipoDispositivo> dispositivos)
        {
            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null)
                {
                    return;// StatusCode(500, "Error interno del servidor");
                }

                try
                {
                    int rowsAffected = 0;
                    await connection.OpenAsync();

                    var query = _configuration.GetSection("Ingenieria:DeleteTipoDispositivo").Value.ToString();

                    foreach(TipoDispositivo tipo in  dispositivos) {

                        using (var command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@id", tipo.IdTipo);
                            rowsAffected += await command.ExecuteNonQueryAsync();
                        }
                    }

                 
                }
                catch (Exception ex)
                {
                   // return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }
        }

        [HttpDelete("DeleteUbicacionAsync")]
        public async Task DeleteUbicacionAsync([FromBody] List<Ubicacion> ubicaciones)
        {
            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null)
                {
                    return; // StatusCode(500, "Error interno del servidor");
                }

                try
                {
                    int rowsAffected = 0;

                    await connection.OpenAsync();

                    var query = _configuration.GetSection("Ingenieria:DeleteUbicacion").Value.ToString();

                    foreach(Ubicacion ubicacion in ubicaciones) {
                        using (var command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@idU", ubicacion.IdUbicacion);

                            rowsAffected += await command.ExecuteNonQueryAsync();
                        }
                    }

                }
                catch (Exception ex)
                {
                   //return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }
        }

        [HttpDelete("DeleteUnidadesMedidaAsync")]
        public async Task DeleteUnidadesMedidaAsync([FromBody] List<UnidadMedida> unidades)
        {
            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null)
                {
                    return;
                }

                try
                {
                    int rowsAffected = 0;
                    await connection.OpenAsync();

                    var query = _configuration.GetSection("Ingenieria:DeleteUnidadesMedida").Value.ToString();

                    foreach (UnidadMedida um in unidades)
                    {

                        using (var command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@idUM", um.IdUnidadMedida);
                            rowsAffected += await command.ExecuteNonQueryAsync();
                        }
                    }


                }
                catch (Exception ex)
                {
                }
            }
        }

        #endregion
    }
}
