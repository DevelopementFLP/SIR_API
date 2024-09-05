using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.Models.Reportes;
using SistemaIntegralReportes.Servicios.Contrato;
using System.Data;

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
            Int32 ParteDelDia = 1;

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
                                DateTime fechaDeBalanza = reader.GetDateTime(0);
                                DateTime fechaDeInnova = reader.GetDateTime(1);
                                string carcasId = reader.GetString(2);
                                string ladoAnimal = reader.GetString(3);
                                string diferenciaDePeso = reader.GetString(4);
                                float pesoInnova = reader.GetFloat(5);
                                double pesoLocal = reader.GetDouble(6);
                                double porsentajeDeMerma = reader.GetDouble(7);
                                Int32 seccionDelDia = reader.GetInt32(8);
                                string etiqueta = reader.GetString(9);
                                string tropa = reader.GetString(10);
                                string proveedor = reader.GetString(11);

                                //Modificacion de modelo
                                porsentajeDeMerma = Math.Round(porsentajeDeMerma, 2);

                                if(seccionDelDia == 0 || seccionDelDia < 5)
                                {
                                    seccionDelDia = ParteDelDia;
                                }
                                else
                                {
                                    ParteDelDia = ParteDelDia + 1;
                                    seccionDelDia = ParteDelDia;
                                }

                                if (seccionDelDia == 2)
                                {
                                    MermaPorPeso lista = new MermaPorPeso
                                    {
                                        FechaDeBalanza = fechaDeBalanza.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                                        FechaDeInnova = fechaDeInnova.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                                        CarcassID = carcasId,
                                        LadoAnimal = ladoAnimal,
                                        DiferenciadePeso = diferenciaDePeso,
                                        PesoInnova = pesoInnova,
                                        PesoLocal = pesoLocal,
                                        PorsentajeDeMerma = porsentajeDeMerma,
                                        SeccionDelDia = seccionDelDia,
                                        Etiqueta = etiqueta,
                                        Tropa = tropa,
                                        Proveedor = proveedor,
                                    };

                                    miListaDeMermasPorFecha.Add(lista);
                                }                                                                                               
                            }
                        }
                    }
                    connection.Close();
                }
                return miListaDeMermasPorFecha.OrderBy(a => a.FechaDeBalanza).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
