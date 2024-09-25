using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.Models.Reportes;
using SistemaIntegralReportes.Servicios.Contrato;
using System.Data;
using static System.Collections.Specialized.BitVector32;

namespace SistemaIntegralReportes.Servicios.Implementacion
{
    public class MermaPorPesoServicio : IMermaPorPeso
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public MermaPorPesoServicio(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("SqlTestConection");
        }

        public async Task<List<MermaPorPeso>> BuscarListaDeMermasPorPeso(string fechaDesde, string fechaHasta)
        {
            List<MermaPorPeso> miListaDeMermasPorFecha= new List<MermaPorPeso>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string sqlMermas = _configuration.GetSection("ReportesMerma:ReporteMermaPorFecha").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlMermas, connection))
                    {
                        //Agrego el parametro de la consulta
                        command.Parameters.AddWithValue("@fechaDesde", fechaDesde);
                        command.Parameters.AddWithValue("@fechaHasta", fechaHasta);

                        command.CommandTimeout = 120;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime fechaDeBalanza = reader.GetDateTime(reader.GetOrdinal("Fecha_Balanza"));
                                DateTime fechaDeInnova = reader.GetDateTime(reader.GetOrdinal("Fecha_Innova"));
                                string carcasId = reader.GetString(reader.GetOrdinal("CarcassID"));
                                string ladoAnimal = reader.GetString(reader.GetOrdinal("Lado_Del_Bicharraco"));
                                string diferenciaDePeso = reader.GetString(reader.GetOrdinal("Diferencias_De_Pesos"));
                                double pesoInnova = reader.GetDouble(reader.GetOrdinal("Peso_Innova"));
                                double pesoLocal = reader.GetDouble(reader.GetOrdinal("Peso_Sir"));   
                                decimal porsentajePorMenudencia = reader.GetDecimal(reader.GetOrdinal("Porcentaje_de_merma_por_menudencia"));         
                                string etiqueta = reader.GetString(reader.GetOrdinal("Etiqueta"));
                                string tropa = reader.GetString(reader.GetOrdinal("Tropa"));
                                string proveedor = reader.GetString(reader.GetOrdinal("Proveedor"));

                                MermaPorPeso lista = new MermaPorPeso
                                {
                                    FechaDeBalanza = fechaDeBalanza.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                                    FechaDeInnova = fechaDeInnova.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                                    CarcassID = carcasId,
                                    LadoAnimal = ladoAnimal,
                                    DiferenciadePeso = diferenciaDePeso,
                                    PesoInnova = pesoInnova,
                                    PesoLocal = pesoLocal,
                                    PorsentajePorMenudencia = porsentajePorMenudencia,               
                                    Etiqueta = etiqueta,
                                    Tropa = tropa,
                                    Proveedor = proveedor,
                                };

                                miListaDeMermasPorFecha.Add(lista);                                                                                      
                            }
                        }
                    }
                    connection.Close();
                }

                //Le agrego la seccion del dia, antes de medio dia seccion 1, despues seccion 2 
                foreach (var seccion in miListaDeMermasPorFecha)
                {
                    DateTime fechaDeBalanza = DateTime.Parse(seccion.FechaDeBalanza); // Convertir de nuevo para comparar

                    if (fechaDeBalanza.TimeOfDay < new TimeSpan(12, 0, 0)) // Antes de las 12 PM
                    {
                        seccion.SeccionDelDia = 1; 
                    }
                    else // Después de las 12 PM
                    {
                        seccion.SeccionDelDia = 2; 
                    }


                    if (seccion.PesoInnova > seccion.PesoLocal)
                    {
                        seccion.PorsentajeDeMerma = Math.Round(((seccion.PesoInnova - seccion.PesoLocal) / seccion.PesoInnova) * 100, 2);
                    }
                    else
                    {
                        seccion.PorsentajeDeMerma = Math.Round(((seccion.PesoLocal - seccion.PesoInnova) / seccion.PesoLocal) * 100, 2);
                    }
                }

                //Parsear las fechas de entrada
                DateTime fechaInicio = DateTime.ParseExact(fechaDesde, "yyyyMMdd HH:mm:ss.fff", null);
                DateTime fechaFin = DateTime.ParseExact(fechaHasta, "yyyyMMdd HH:mm:ss.fff", null);

                List<MermaPorPeso> resultadoFiltrado = new List<MermaPorPeso>();

                // me quedo con dia desde parte del dia 2 y dia hasta parte del dia 1
                foreach (var item in miListaDeMermasPorFecha)
                {
                    DateTime fechaDeBalanza = DateTime.Parse(item.FechaDeBalanza); 
                    if ((fechaDeBalanza.Date == fechaInicio.Date && item.SeccionDelDia == 2) ||
                        (fechaDeBalanza.Date == fechaFin.Date && item.SeccionDelDia == 1))
                    {
                        resultadoFiltrado.Add(item);
                    }
                }

                return resultadoFiltrado.OrderBy(item => item.FechaDeBalanza).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
