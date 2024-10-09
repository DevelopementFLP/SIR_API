using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.DTO.FichaTecnica;
using SistemaIntegralReportes.Servicios.Contrato.FichaTecnica;
using Microsoft.Extensions.Configuration;

namespace SistemaIntegralReportes.Servicios.Implementacion.FichaTecnica
{
    public class FtPresentacionDeEnvaseService : IFtPresentacionDeEnvase
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public FtPresentacionDeEnvaseService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("SqlTestConection");
        }

        public async Task<List<PresentacionDeEnvaseDTO>> Lista()
        {
            List<PresentacionDeEnvaseDTO> listaPresentaciones = new List<PresentacionDeEnvaseDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlListar = _configuration.GetSection("FichaTecnica:FtListarPresentacionDeEnvase").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlListar, connection))
                    {
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                listaPresentaciones.Add(new PresentacionDeEnvaseDTO
                                {
                                    IdPresentacionDeEnvase = reader.GetInt32(reader.GetOrdinal("IdPresentacionDeEnvase")),
                                    Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                    Descripcion = reader.GetString(reader.GetOrdinal("Descripcion"))
                                });
                            }
                        }
                    }
                }

                return listaPresentaciones;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Presentaciones de Envase", ex);
            }
        }

        public async Task<PresentacionDeEnvaseDTO> Crear(PresentacionDeEnvaseDTO modelo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlCrear = _configuration.GetSection("FichaTecnica:FtCrearPresentacionDeEnvase").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlCrear, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", modelo.Nombre);
                        command.Parameters.AddWithValue("@Descripcion", modelo.Descripcion);

                        var respuestaDelModelo = await command.ExecuteReaderAsync();

                        if (await respuestaDelModelo.ReadAsync())
                        {
                            return new PresentacionDeEnvaseDTO
                            {
                                IdPresentacionDeEnvase = respuestaDelModelo.GetInt32(respuestaDelModelo.GetOrdinal("IdPresentacionDeEnvase")),
                                Nombre = respuestaDelModelo.GetString(respuestaDelModelo.GetOrdinal("Nombre")),
                                Descripcion = respuestaDelModelo.GetString(respuestaDelModelo.GetOrdinal("Descripcion"))
                            };
                        }
                        else
                        {
                            throw new TaskCanceledException("No se pudo crear la Presentación de Envase");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la Presentación de Envase", ex);
            }
        }

        public async Task<bool> Editar(PresentacionDeEnvaseDTO modelo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlEditar = _configuration.GetSection("FichaTecnica:FtEditarPresentacionDeEnvase").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlEditar, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", modelo.Nombre);
                        command.Parameters.AddWithValue("@Descripcion", modelo.Descripcion);
                        command.Parameters.AddWithValue("@IdPresentacionDeEnvase", modelo.IdPresentacionDeEnvase);

                        int filasAfectadas = await command.ExecuteNonQueryAsync();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar la Presentación de Envase", ex);
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlEliminar = _configuration.GetSection("FichaTecnica:FtEliminarPresentacionDeEnvase").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlEliminar, connection))
                    {
                        command.Parameters.AddWithValue("@IdPresentacionDeEnvase", id);

                        int filasAfectadas = await command.ExecuteNonQueryAsync();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la Presentación de Envase", ex);
            }
        }
    }
}
