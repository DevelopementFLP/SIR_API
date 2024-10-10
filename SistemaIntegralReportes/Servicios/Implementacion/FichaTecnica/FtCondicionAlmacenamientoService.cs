using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.DTO.FichaTecnica;
using SistemaIntegralReportes.Servicios.Contrato.FichaTecnica;

namespace SistemaIntegralReportes.Servicios.Implementacion.FichaTecnica
{
    public class FtCondicionAlmacenamientoService: IFtCondicionAlmacenamiento
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;


        public FtCondicionAlmacenamientoService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("SqlTestConection");
        }

        public async Task<List<CondicionDeAlmacenamientoDTO>> Lista()
        {
            List<CondicionDeAlmacenamientoDTO> listaMarcas = new List<CondicionDeAlmacenamientoDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlEditar = _configuration.GetSection("FichaTecnica:FtListarCondicionAlmacenamiento").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlEditar, connection))
                    {
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                listaMarcas.Add(new CondicionDeAlmacenamientoDTO
                                {
                                    IdCondicionDeAlmacenamiento = reader.GetInt32(reader.GetOrdinal("idCondicionAlmacenamiento")),
                                    Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                                    Descripcion = reader.GetString(reader.GetOrdinal("descripcion"))
                                });
                            }
                        }
                    }
                }

                return listaMarcas;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Condiciones", ex);
            }
        }

        public async Task<CondicionDeAlmacenamientoDTO> Crear(CondicionDeAlmacenamientoDTO modelo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlCrear = _configuration.GetSection("FichaTecnica:FtCrearCondicionAlmacenamiento").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlCrear, connection))
                    {
                        // Agregar parámetros
                        command.Parameters.AddWithValue("@Nombre", modelo.Nombre);
                        command.Parameters.AddWithValue("@Descripcion", modelo.Descripcion);

                        // Ejecutar el comando y obtener los resultados
                        var respuestaDelModelo = await command.ExecuteReaderAsync();

                        if (await respuestaDelModelo.ReadAsync())
                        {
                            return new CondicionDeAlmacenamientoDTO
                            {
                                IdCondicionDeAlmacenamiento = respuestaDelModelo.GetInt32(respuestaDelModelo.GetOrdinal("idCondicionAlmacenamiento")),
                                Nombre = respuestaDelModelo.GetString(respuestaDelModelo.GetOrdinal("nombre")),
                                Descripcion = respuestaDelModelo.GetString(respuestaDelModelo.GetOrdinal("descripcion"))
                            };
                        }
                        else
                        {
                            throw new TaskCanceledException("No se pudo crear la Condiciones");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la Condicion", ex);
            }
        }

        public async Task<bool> Editar(CondicionDeAlmacenamientoDTO modelo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlEditar = _configuration.GetSection("FichaTecnica:FtEditarCondicionAlmacenamiento").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlEditar, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", modelo.Nombre);
                        command.Parameters.AddWithValue("@Descripcion", modelo.Descripcion);
                        command.Parameters.AddWithValue("@IdCondicionAlmacenamiento", modelo.IdCondicionDeAlmacenamiento);

                        int filasAfectadas = await command.ExecuteNonQueryAsync();
                        return filasAfectadas > 0; 
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar la Condicion", ex);
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlEditar = _configuration.GetSection("FichaTecnica:FtEliminarCondicionAlmacenamiento").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlEditar, connection))
                    {
                        command.Parameters.AddWithValue("@IdCondicionAlmacenamiento", id);

                        int filasAfectadas = await command.ExecuteNonQueryAsync();
                        return filasAfectadas > 0; 
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la marca", ex);
            }
        }

       
    }
}
