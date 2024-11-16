using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.DTO.FichaTecnica.CrearPlantillas;
using SistemaIntegralReportes.Servicios.Contrato.FichaTecnica;

namespace SistemaIntegralReportes.Servicios.Implementacion.FichaTecnica
{
    public class FtEspecificacionesService : IFtEspecificacionesPlantilla
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public FtEspecificacionesService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlTestConection");
            _configuration = configuration;
        }

        public async Task<List<EspecificacionesPlantillaDTO>> ListaDeEspecificaciones()
        {
            List<EspecificacionesPlantillaDTO> especificaciones = new List<EspecificacionesPlantillaDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();


                    string sqlConsulta = _configuration.GetSection("FichaTecnica:FtListaDeEspecificaciones").Value;

                    using (SqlCommand command = new SqlCommand(sqlConsulta, connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var especificacion = new EspecificacionesPlantillaDTO
                                {
                                    IdPlantilla = reader.GetInt32(reader.GetOrdinal("IdPlantilla")),
                                    SeccionDePlantilla = reader["SeccionDePlantilla"].ToString(),
                                    Nombre = reader["nombre"].ToString(),
                                    GrasaVisible = reader["grasaVisible"].ToString(),
                                    EspesorCobertura = reader["espesorCobertura"].ToString(),
                                    Ganglios = reader["ganglios"].ToString(),
                                    Hematomas = reader["hematomas"].ToString(),
                                    HuesosCartilagos = reader["huesosCartilagos"].ToString(),
                                    ElementosExtraños = reader["elementosExtraños"].ToString(),
                                    IdColor = (int)reader["idColor"],
                                    IdOlor = (int)reader["idOlor"],
                                    IdPh = (int)reader["idPh"],
                                    AerobiosMesofilosTotales = reader["aerobiosMesofilosTotales"].ToString(),
                                    Enterobacterias = reader["enterobacterias"].ToString(),
                                    Stec0157 = reader["stec0157"].ToString(),
                                    StecNo0157 = reader["stecNo0157"].ToString(),
                                    Salmonella = reader["salmonella"].ToString(),
                                    Estafilococos = reader["estafilococos"].ToString(),
                                    Pseudomonas = reader["pseudomonas"].ToString(),
                                    EscherichiaColi = reader["escherichiaColi"].ToString(),
                                    ColiformesTotales = reader["coliformesTotales"].ToString(),
                                    ColiformesFecales = reader["coliformesFecales"].ToString()
                                };

                                especificaciones.Add(especificacion);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las especificaciones de la plantilla", ex);
            }

            return especificaciones.OrderBy(nombre => nombre.Nombre).ToList();
        }


        public async Task<EspecificacionesPlantillaDTO> BuscarPlantillaEspecificaciones(string nombreDePlantilla)
        {
            EspecificacionesPlantillaDTO especificacion = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlConsulta = _configuration.GetSection("FichaTecnica:FtBuscarPlantillaParaEditarEspecificaciones").Value;

                    using (SqlCommand command = new SqlCommand(sqlConsulta, connection))
                    {
                        command.Parameters.AddWithValue("@nombreDePlantilla", "%" + nombreDePlantilla + "%");


                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                // Mapear los resultados a tu DTO
                                especificacion = new EspecificacionesPlantillaDTO
                                {
                                    IdPlantilla = reader.GetInt32(reader.GetOrdinal("IdPlantilla")),
                                    SeccionDePlantilla = reader["SeccionDePlantilla"].ToString(),
                                    Nombre = reader["nombre"].ToString(),
                                    GrasaVisible = reader["grasaVisible"].ToString(),
                                    EspesorCobertura = reader["espesorCobertura"].ToString(),
                                    Ganglios = reader["ganglios"].ToString(),
                                    Hematomas = reader["hematomas"].ToString(),
                                    HuesosCartilagos = reader["huesosCartilagos"].ToString(),
                                    ElementosExtraños = reader["elementosExtraños"].ToString(),
                                    IdColor = (int)reader["idColor"],
                                    IdOlor = (int)reader["idOlor"],
                                    IdPh = (int)reader["idPh"],
                                    AerobiosMesofilosTotales = reader["aerobiosMesofilosTotales"].ToString(),
                                    Enterobacterias = reader["enterobacterias"].ToString(),
                                    Stec0157 = reader["stec0157"].ToString(),
                                    StecNo0157 = reader["stecNo0157"].ToString(),
                                    Salmonella = reader["salmonella"].ToString(),
                                    Estafilococos = reader["estafilococos"].ToString(),
                                    Pseudomonas = reader["pseudomonas"].ToString(),
                                    EscherichiaColi = reader["escherichiaColi"].ToString(),
                                    ColiformesTotales = reader["coliformesTotales"].ToString(),
                                    ColiformesFecales = reader["coliformesFecales"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar la plantilla de especificaciones", ex);
            }

            return especificacion;
        }



        public async Task<EspecificacionesPlantillaDTO> Crear(EspecificacionesPlantillaDTO modelo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    string sqlCrear = _configuration.GetSection("FichaTecnica:FtCrearPlantillaEspecificaciones").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlCrear, connection))
                    {
                        command.Parameters.AddWithValue("@seccionDePlantilla", modelo.SeccionDePlantilla);
                        command.Parameters.AddWithValue("@nombre", modelo.Nombre);
                        command.Parameters.AddWithValue("@grasaVisible", modelo.GrasaVisible);
                        command.Parameters.AddWithValue("@espesorCobertura", modelo.EspesorCobertura);
                        command.Parameters.AddWithValue("@ganglios", modelo.Ganglios);
                        command.Parameters.AddWithValue("@hematomas", modelo.Hematomas);
                        command.Parameters.AddWithValue("@huesosCartilagos", modelo.HuesosCartilagos);
                        command.Parameters.AddWithValue("@elementosExtraños", modelo.ElementosExtraños);
                        command.Parameters.AddWithValue("@idColor", modelo.IdColor);
                        command.Parameters.AddWithValue("@idOlor", modelo.IdOlor);
                        command.Parameters.AddWithValue("@idPh", modelo.IdPh);
                        command.Parameters.AddWithValue("@aerobiosMesofilosTotales", modelo.AerobiosMesofilosTotales);
                        command.Parameters.AddWithValue("@enterobacterias", modelo.Enterobacterias);
                        command.Parameters.AddWithValue("@stec0157", modelo.Stec0157);
                        command.Parameters.AddWithValue("@stecNo0157", modelo.StecNo0157);
                        command.Parameters.AddWithValue("@salmonella", modelo.Salmonella);
                        command.Parameters.AddWithValue("@estafilococos", modelo.Estafilococos);
                        command.Parameters.AddWithValue("@pseudomonas", modelo.Pseudomonas);
                        command.Parameters.AddWithValue("@escherichiaColi", modelo.EscherichiaColi);
                        command.Parameters.AddWithValue("@coliformesTotales", modelo.ColiformesTotales);
                        command.Parameters.AddWithValue("@coliformesFecales", modelo.ColiformesFecales);

                        var respuestaDelModelo = await command.ExecuteReaderAsync();

                        if (await respuestaDelModelo.ReadAsync())
                        {
                            return modelo;
                        }
                        else
                        {
                            throw new TaskCanceledException("No se pudo crear la especificación.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la especificación.", ex);
            }
        }

        public async Task<bool> Editar(EspecificacionesPlantillaDTO modelo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlEditar = _configuration.GetSection("FichaTecnica:FtEditarPlantillaDeEspecificaciones").Value;

                    using (SqlCommand command = new SqlCommand(sqlEditar, connection))
                    {
                        // Agregar parámetros
                        command.Parameters.AddWithValue("@IdPlantilla", modelo.IdPlantilla);
                        command.Parameters.AddWithValue("@SeccionDePlantilla", modelo.SeccionDePlantilla);
                        command.Parameters.AddWithValue("@Nombre", modelo.Nombre);
                        command.Parameters.AddWithValue("@GrasaVisible", modelo.GrasaVisible);
                        command.Parameters.AddWithValue("@EspesorCobertura", modelo.EspesorCobertura);
                        command.Parameters.AddWithValue("@Ganglios", modelo.Ganglios);
                        command.Parameters.AddWithValue("@Hematomas", modelo.Hematomas);
                        command.Parameters.AddWithValue("@HuesosCartilagos", modelo.HuesosCartilagos);
                        command.Parameters.AddWithValue("@ElementosExtraños", modelo.ElementosExtraños);
                        command.Parameters.AddWithValue("@IdColor", modelo.IdColor);
                        command.Parameters.AddWithValue("@IdOlor", modelo.IdOlor);
                        command.Parameters.AddWithValue("@IdPh", modelo.IdPh);
                        command.Parameters.AddWithValue("@AerobiosMesofilosTotales", modelo.AerobiosMesofilosTotales);
                        command.Parameters.AddWithValue("@Enterobacterias", modelo.Enterobacterias);
                        command.Parameters.AddWithValue("@Stec0157", modelo.Stec0157);
                        command.Parameters.AddWithValue("@StecNo0157", modelo.StecNo0157);
                        command.Parameters.AddWithValue("@Salmonella", modelo.Salmonella);
                        command.Parameters.AddWithValue("@Estafilococos", modelo.Estafilococos);
                        command.Parameters.AddWithValue("@Pseudomonas", modelo.Pseudomonas);
                        command.Parameters.AddWithValue("@EscherichiaColi", modelo.EscherichiaColi);
                        command.Parameters.AddWithValue("@ColiformesTotales", modelo.ColiformesTotales);
                        command.Parameters.AddWithValue("@ColiformesFecales", modelo.ColiformesFecales);

                        // Ejecutar el comando y obtener el número de filas afectadas
                        int filasAfectadas = await command.ExecuteNonQueryAsync();

                        // Retornar verdadero si se actualizó al menos una fila
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar la Especificación de la Plantilla", ex);
            }
        }

    }
}
