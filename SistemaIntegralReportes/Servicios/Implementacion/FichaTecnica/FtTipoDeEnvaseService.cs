using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.DTO.FichaTecnica;
using SistemaIntegralReportes.Servicios.Contrato.FichaTecnica;
using Microsoft.Extensions.Configuration;

namespace SistemaIntegralReportes.Servicios.Implementacion.FichaTecnica
{
    public class FtTipoDeEnvaseService : IFtTipoDeEnvase
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public FtTipoDeEnvaseService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("SqlTestConection");
        }

        public async Task<List<TipoDeEnvaseDTO>> Lista()
        {
            List<TipoDeEnvaseDTO> listaEnvases = new List<TipoDeEnvaseDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlListar = _configuration.GetSection("FichaTecnica:FtListarTipoDeEnvase").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlListar, connection))
                    {
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                listaEnvases.Add(new TipoDeEnvaseDTO
                                {
                                    IdTipoDeEnvase = reader.GetInt32(reader.GetOrdinal("IdTipoDeEnvase")),
                                    Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                    Descripcion = reader.GetString(reader.GetOrdinal("Descripcion"))
                                });
                            }
                        }
                    }
                }

                return listaEnvases;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Tipos de Envase", ex);
            }
        }

        public async Task<TipoDeEnvaseDTO> Crear(TipoDeEnvaseDTO modelo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlCrear = _configuration.GetSection("FichaTecnica:FtCrearTipoDeEnvase").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlCrear, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", modelo.Nombre);
                        command.Parameters.AddWithValue("@Descripcion", modelo.Descripcion);

                        var respuestaDelModelo = await command.ExecuteReaderAsync();

                        if (await respuestaDelModelo.ReadAsync())
                        {
                            return new TipoDeEnvaseDTO
                            {
                                IdTipoDeEnvase = respuestaDelModelo.GetInt32(respuestaDelModelo.GetOrdinal("IdTipoDeEnvase")),
                                Nombre = respuestaDelModelo.GetString(respuestaDelModelo.GetOrdinal("Nombre")),
                                Descripcion = respuestaDelModelo.GetString(respuestaDelModelo.GetOrdinal("Descripcion"))
                            };
                        }
                        else
                        {
                            throw new TaskCanceledException("No se pudo crear el Tipo de Envase");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el Tipo de Envase", ex);
            }
        }

        public async Task<bool> Editar(TipoDeEnvaseDTO modelo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlEditar = _configuration.GetSection("FichaTecnica:FtEditarTipoDeEnvase").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlEditar, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", modelo.Nombre);
                        command.Parameters.AddWithValue("@Descripcion", modelo.Descripcion);
                        command.Parameters.AddWithValue("@IdTipoDeEnvase", modelo.IdTipoDeEnvase);

                        int filasAfectadas = await command.ExecuteNonQueryAsync();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar el Tipo de Envase", ex);
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlEliminar = _configuration.GetSection("FichaTecnica:FtEliminarTipoDeEnvase").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlEliminar, connection))
                    {
                        command.Parameters.AddWithValue("@IdTipoDeEnvase", id);

                        int filasAfectadas = await command.ExecuteNonQueryAsync();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el Tipo de Envase", ex);
            }
        }
    }
}
