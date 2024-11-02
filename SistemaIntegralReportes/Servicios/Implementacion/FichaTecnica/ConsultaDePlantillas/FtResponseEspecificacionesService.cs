using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.DTO.FichaTecnica.ConsultaDePlantillas;
using SistemaIntegralReportes.Servicios.Contrato.FichaTecnica.ConsultaDePlantillas;

namespace SistemaIntegralReportes.Servicios.Implementacion.FichaTecnica.ConsultaDePlantillas
{
    public class FtResponseEspecificacionesService : IFtResponseEspecificacionesPlantilla
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public FtResponseEspecificacionesService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlTestConection");
            _configuration = configuration;
        }

        public async Task<List<ResponseEspecificacionesDTO>> ObtenerEspecificacionesPlantilla(int idPlantilla)
        {
            var especificaciones = new List<ResponseEspecificacionesDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlQuery = _configuration.GetValue<string>("FichaTecnica:FtBuscarPlantillaEspecificaiones");

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        // Agregar el parámetro
                        command.Parameters.AddWithValue("@idPlantilla", idPlantilla);

                        // Ejecutar el comando y obtener los resultados
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var especificacion = new ResponseEspecificacionesDTO
                                {
                                    IdPlantilla = reader.GetInt32(reader.GetOrdinal("idPlantilla")),
                                    Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                                    GrasaVisible = reader.GetString(reader.GetOrdinal("grasaVisible")),
                                    EspesorCobertura = reader.GetString(reader.GetOrdinal("espesorCobertura")),
                                    Ganglios = reader.GetString(reader.GetOrdinal("ganglios")),
                                    Hematomas = reader.GetString(reader.GetOrdinal("hematomas")),
                                    HuesosCartilagos = reader.GetString(reader.GetOrdinal("huesosCartilagos")),
                                    ElementosExtraños = reader.GetString(reader.GetOrdinal("elementosExtraños")),
                                    Color = reader.GetString(reader.GetOrdinal("Color")),
                                    Olor = reader.GetString(reader.GetOrdinal("Olor")),
                                    Ph = reader.GetDecimal(reader.GetOrdinal("Ph")),
                                    AerobiosMesofilosTotales = reader.GetString(reader.GetOrdinal("aerobiosMesofilosTotales")),
                                    Enterobacterias = reader.GetString(reader.GetOrdinal("enterobacterias")),
                                    Stec0157 = reader.GetString(reader.GetOrdinal("stec0157")),
                                    StecNo0157 = reader.GetString(reader.GetOrdinal("stecNo0157")),
                                    Salmonella = reader.GetString(reader.GetOrdinal("salmonella")),
                                    Estafilococos = reader.GetString(reader.GetOrdinal("estafilococos")),
                                    Pseudomonas = reader.GetString(reader.GetOrdinal("pseudomonas")),
                                    EscherichiaColi = reader.GetString(reader.GetOrdinal("escherichiaColi")),
                                    ColiformesTotales = reader.GetString(reader.GetOrdinal("coliformesTotales"))
                                };

                                especificaciones.Add(especificacion);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las Especificaciones de la Plantilla", ex);
            }

            return especificaciones;
        }
    }
}
