using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.DTO.FichaTecnica.CrearPlantillas;
using SistemaIntegralReportes.Servicios.Contrato.FichaTecnica;

namespace SistemaIntegralReportes.Servicios.Implementacion.FichaTecnica
{
    public class FtAspectosGeneralesService : IFtAspectosGeneralesPlantilla
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public FtAspectosGeneralesService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlTestConection"); 
            _configuration = configuration;
        }

        public async Task<List<AspectosGeneralesPlantillaDTO>> ListaDeAspectosGenerales()
        {
            List<AspectosGeneralesPlantillaDTO> aspectosGenerales = new List<AspectosGeneralesPlantillaDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlConsulta = _configuration.GetSection("FichaTecnica:FtListaDeAspectosGenerales").Value;

                    using (SqlCommand command = new SqlCommand(sqlConsulta, connection))
                    {

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
       
                                var aspectoGeneral = new AspectosGeneralesPlantillaDTO
                                {
                                    IdPlantilla = reader.GetInt32(reader.GetOrdinal("IdPlantilla")),
                                    SeccionDePlantilla = reader["SeccionDePlantilla"].ToString(),
                                    Nombre = reader["Nombre"].ToString(),
                                    NombreDeProducto = reader["NombreDeProducto"].ToString(),
                                    IdMarca = (int)reader["IdMarca"],
                                    IdTipoDeUso = (int)reader["IdTipoDeUso"],
                                    IdAlergeno = (int)reader["IdAlergeno"],
                                    IdCondicionAlmacenamiento = (int)reader["IdCondicionAlmacenamiento"],
                                    IdVidaUtil = (int)reader["IdVidaUtil"],
                                    IdTipoDeEnvase = (int)reader["IdTipoDeEnvase"],
                                    IdPresentacionDeEnvase = (int)reader["IdPresentacionDeEnvase"],
                                    PesoPromedio = reader["PesoPromedio"].ToString(),
                                    UnidadesPorCaja = reader["UnidadesPorCaja"].ToString(),
                                    Dimensiones = reader["Dimensiones"].ToString()
                                };

                                aspectosGenerales.Add(aspectoGeneral);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los aspectos generales de la plantilla", ex);
            }

            return aspectosGenerales.OrderBy(nombre => nombre.Nombre).ToList();
        }


        public async Task<AspectosGeneralesPlantillaDTO> Crear(AspectosGeneralesPlantillaDTO modelo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlCrear = _configuration.GetSection("FichaTecnica:FtCrearPlantillaAspectosGenerales").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlCrear, connection))
                    {
                        // Agregar parámetros
                        command.Parameters.AddWithValue("@SeccionDePlantilla", modelo.SeccionDePlantilla);
                        command.Parameters.AddWithValue("@Nombre", modelo.Nombre);
                        command.Parameters.AddWithValue("@nombreDeProducto", modelo.NombreDeProducto);
                        command.Parameters.AddWithValue("@IdMarca", modelo.IdMarca);
                        command.Parameters.AddWithValue("@IdTipoDeUso", modelo.IdTipoDeUso);
                        command.Parameters.AddWithValue("@IdAlergeno", modelo.IdAlergeno);
                        command.Parameters.AddWithValue("@IdCondicionAlmacenamiento", modelo.IdCondicionAlmacenamiento);
                        command.Parameters.AddWithValue("@IdVidaUtil", modelo.IdVidaUtil);
                        command.Parameters.AddWithValue("@IdTipoDeEnvase", modelo.IdTipoDeEnvase);
                        command.Parameters.AddWithValue("@IdPresentacionDeEnvase", modelo.IdPresentacionDeEnvase);
                        command.Parameters.AddWithValue("@PesoPromedio", modelo.PesoPromedio);
                        command.Parameters.AddWithValue("@UnidadesPorCaja", modelo.UnidadesPorCaja);
                        command.Parameters.AddWithValue("@Dimensiones", modelo.Dimensiones);

                        // Ejecutar el comando y obtener los resultados
                        var respuestaDelModelo = await command.ExecuteReaderAsync();

                        if (await respuestaDelModelo.ReadAsync())
                        {
                            return modelo;
                        }
                        else
                        {
                            throw new TaskCanceledException("No se pudo crear el Aspecto General de la Plantilla");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el Aspecto General de la Plantilla", ex);
            }
        }
        
        public async Task<AspectosGeneralesPlantillaDTO> BuscarPlantillaAspectosGenerales(string descripcionDePlantilla)
        {
            AspectosGeneralesPlantillaDTO aspectoGeneral = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlBuscar = _configuration.GetSection("FichaTecnica:FtBuscarPlantillaParaEditarAspectosGenerales").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlBuscar, connection))
                    {
                        // Añadir el parámetro con wildcards para LIKE
                        command.Parameters.AddWithValue("@descripcionDePlantilla", "%" + descripcionDePlantilla + "%");

                        // Ejecutar el comando y obtener los resultados
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                // Mapear los resultados a tu DTO
                                aspectoGeneral = new AspectosGeneralesPlantillaDTO
                                {
                                    IdPlantilla = reader.GetInt32(reader.GetOrdinal("IdPlantilla")),
                                    SeccionDePlantilla = reader["SeccionDePlantilla"].ToString(),
                                    Nombre = reader["Nombre"].ToString(),
                                    NombreDeProducto = reader["NombreDeProducto"].ToString(),
                                    IdMarca = (int)reader["IdMarca"],
                                    IdTipoDeUso = (int)reader["IdTipoDeUso"],
                                    IdAlergeno = (int)reader["IdAlergeno"],
                                    IdCondicionAlmacenamiento = (int)reader["IdCondicionAlmacenamiento"],
                                    IdVidaUtil = (int)reader["IdVidaUtil"],
                                    IdTipoDeEnvase = (int)reader["IdTipoDeEnvase"],
                                    IdPresentacionDeEnvase = (int)reader["IdPresentacionDeEnvase"],
                                    PesoPromedio = reader["PesoPromedio"].ToString(),
                                    UnidadesPorCaja = reader["UnidadesPorCaja"].ToString(),
                                    Dimensiones = reader["Dimensiones"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar la plantilla", ex);
            }

            return aspectoGeneral; 
        }

        public async Task<bool> Editar(AspectosGeneralesPlantillaDTO modelo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlEditar = _configuration.GetSection("FichaTecnica:FtEditarPlantillaAspectosGenerales").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlEditar, connection))
                    {
                        // Agregar parámetros
                        command.Parameters.AddWithValue("@IdPlantilla", modelo.IdPlantilla);
                        command.Parameters.AddWithValue("@Nombre", modelo.Nombre);
                        command.Parameters.AddWithValue("@nombreDeProducto", modelo.NombreDeProducto);
                        command.Parameters.AddWithValue("@IdMarca", modelo.IdMarca);
                        command.Parameters.AddWithValue("@IdTipoDeUso", modelo.IdTipoDeUso);
                        command.Parameters.AddWithValue("@IdAlergeno", modelo.IdAlergeno);
                        command.Parameters.AddWithValue("@IdCondicionAlmacenamiento", modelo.IdCondicionAlmacenamiento);
                        command.Parameters.AddWithValue("@IdVidaUtil", modelo.IdVidaUtil);
                        command.Parameters.AddWithValue("@IdTipoDeEnvase", modelo.IdTipoDeEnvase);
                        command.Parameters.AddWithValue("@IdPresentacionDeEnvase", modelo.IdPresentacionDeEnvase);
                        command.Parameters.AddWithValue("@PesoPromedio", modelo.PesoPromedio);
                        command.Parameters.AddWithValue("@UnidadesPorCaja", modelo.UnidadesPorCaja);
                        command.Parameters.AddWithValue("@Dimensiones", modelo.Dimensiones);

                        // Ejecutar el comando y obtener el número de filas afectadas
                        int filasAfectadas = await command.ExecuteNonQueryAsync();

                        // Retornar verdadero si se actualizó al menos una fila
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar el Aspecto General de la Plantilla", ex);
            }
        }

    }
}
