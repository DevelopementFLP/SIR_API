using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.DTO.FichaTecnica;
using SistemaIntegralReportes.Servicios.Contrato.FichaTecnica;
using Microsoft.Extensions.Configuration;

namespace SistemaIntegralReportes.Servicios.Implementacion.FichaTecnica
{
    public class FtTipoDeAlimentacionService : IFtTipoDeAlimentacion
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public FtTipoDeAlimentacionService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("SqlTestConection");
        }

        public async Task<List<TipoDeAlimentacionDTO>> Lista()
        {
            List<TipoDeAlimentacionDTO> listaAlimentacion = new List<TipoDeAlimentacionDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlListar = _configuration.GetSection("FichaTecnica:FtListarTipoAlimentacion").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlListar, connection))
                    {
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                listaAlimentacion.Add(new TipoDeAlimentacionDTO
                                {
                                    IdAlimentacion = reader.GetInt32(reader.GetOrdinal("IdAlimentacion")),
                                    Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                    Tipo = reader.GetString(reader.GetOrdinal("Tipo"))
                                });
                            }
                        }
                    }
                }

                return listaAlimentacion;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Tipos de Alimentación", ex);
            }
        }

        public async Task<TipoDeAlimentacionDTO> Crear(TipoDeAlimentacionDTO modelo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlCrear = _configuration.GetSection("FichaTecnica:FtCrearTipoAlimentacion").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlCrear, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", modelo.Nombre);
                        command.Parameters.AddWithValue("@Tipo", modelo.Tipo);

                        var respuestaDelModelo = await command.ExecuteReaderAsync();

                        if (await respuestaDelModelo.ReadAsync())
                        {
                            return new TipoDeAlimentacionDTO
                            {
                                IdAlimentacion = respuestaDelModelo.GetInt32(respuestaDelModelo.GetOrdinal("IdAlimentacion")),
                                Nombre = respuestaDelModelo.GetString(respuestaDelModelo.GetOrdinal("Nombre")),
                                Tipo = respuestaDelModelo.GetString(respuestaDelModelo.GetOrdinal("Tipo"))
                            };
                        }
                        else
                        {
                            throw new TaskCanceledException("No se pudo crear el Tipo de Alimentación");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el Tipo de Alimentación", ex);
            }
        }

        public async Task<bool> Editar(TipoDeAlimentacionDTO modelo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlEditar = _configuration.GetSection("FichaTecnica:FtEditarTipoAlimentacion").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlEditar, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", modelo.Nombre);
                        command.Parameters.AddWithValue("@Tipo", modelo.Tipo);
                        command.Parameters.AddWithValue("@IdAlimentacion", modelo.IdAlimentacion);

                        int filasAfectadas = await command.ExecuteNonQueryAsync();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar el Tipo de Alimentación", ex);
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlEliminar = _configuration.GetSection("FichaTecnica:FtEliminarTipoAlimentacion").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlEliminar, connection))
                    {
                        command.Parameters.AddWithValue("@idAlimentacion", id);

                        int filasAfectadas = await command.ExecuteNonQueryAsync();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el Tipo de Alimentación", ex);
            }
        }
    }
}
