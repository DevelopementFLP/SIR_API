using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.DTO.FichaTecnica;
using SistemaIntegralReportes.Servicios.Contrato.FichaTecnica;

namespace SistemaIntegralReportes.Servicios.Implementacion.FichaTecnica
{
    public class FtTipoDeUsoService : IFtTipoDeUso
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public FtTipoDeUsoService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("SqlTestConection");
        }

        public async Task<List<TipoDeUsoDTO>> Lista()
        {
            List<TipoDeUsoDTO> listaTiposDeUso = new List<TipoDeUsoDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlListar = _configuration.GetSection("FichaTecnica:FtListarTiposDeUso").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlListar, connection))
                    {
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                listaTiposDeUso.Add(new TipoDeUsoDTO
                                {
                                    IdTipoDeUso = reader.GetInt32(reader.GetOrdinal("IdTipoDeUso")),
                                    Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                    Descripcion = reader.GetString(reader.GetOrdinal("Descripcion"))
                                });
                            }
                        }
                    }
                }

                return listaTiposDeUso;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Tipos de Uso", ex);
            }
        }

        public async Task<TipoDeUsoDTO> Crear(TipoDeUsoDTO modelo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlCrear = _configuration.GetSection("FichaTecnica:FtCrearTipoDeUso").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlCrear, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", modelo.Nombre);
                        command.Parameters.AddWithValue("@Descripcion", modelo.Descripcion);

                        var respuestaDelModelo = await command.ExecuteReaderAsync();

                        if (await respuestaDelModelo.ReadAsync())
                        {
                            return new TipoDeUsoDTO
                            {
                                IdTipoDeUso = respuestaDelModelo.GetInt32(respuestaDelModelo.GetOrdinal("IdTipoDeUso")),
                                Nombre = respuestaDelModelo.GetString(respuestaDelModelo.GetOrdinal("Nombre")),
                                Descripcion = respuestaDelModelo.GetString(respuestaDelModelo.GetOrdinal("Descripcion"))
                            };
                        }
                        else
                        {
                            throw new TaskCanceledException("No se pudo crear el Tipo de Uso");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el Tipo de Uso", ex);
            }
        }

        public async Task<bool> Editar(TipoDeUsoDTO modelo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlEditar = _configuration.GetSection("FichaTecnica:FtEditarTipoDeUso").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlEditar, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", modelo.Nombre);
                        command.Parameters.AddWithValue("@Descripcion", modelo.Descripcion);
                        command.Parameters.AddWithValue("@IdTipoDeUso", modelo.IdTipoDeUso);

                        int filasAfectadas = await command.ExecuteNonQueryAsync();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar el Tipo de Uso", ex);
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlEliminar = _configuration.GetSection("FichaTecnica:FtEliminarTipoDeUso").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlEliminar, connection))
                    {
                        command.Parameters.AddWithValue("@IdTipoDeUso", id);

                        int filasAfectadas = await command.ExecuteNonQueryAsync();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el Tipo de Uso", ex);
            }
        }

       
    }
}
