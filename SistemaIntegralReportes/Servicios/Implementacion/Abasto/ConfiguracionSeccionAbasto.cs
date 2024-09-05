using AutoMapper;
using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.DTO.Abasto;
using SistemaIntegralReportes.Models.Configuraciones;
using SistemaIntegralReportes.Servicios.Contrato.Abasto;

namespace SistemaIntegralReportes.Servicios.Implementacion.Abasto
{
    public class ConfiguracionSeccionAbasto : IConfiguracionAbasto
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public ConfiguracionSeccionAbasto(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("SqlTestConection");
        }

        public async Task<List<ParametrosDw_Abasto>> GetParametrosSeccionAbasto()
        {
            List<ParametrosDw_Abasto> _listaDeParametros = new List<ParametrosDw_Abasto>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlConfiguracionAbasto = _configuration.GetSection("ConfigurationParameters:GetParametrosSeccionAbasto").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlConfiguracionAbasto, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int idConfiguracion = reader.GetInt32(0);
                                string parametroDeConfiguracion = reader.GetString(1);
                                string descripcion = reader.GetString(2);

                                ParametrosDw_Abasto lecturas = new ParametrosDw_Abasto
                                {
                                    IdConfiguracion = idConfiguracion,
                                    ParametroDeConfiguracion = parametroDeConfiguracion,
                                    Descripcion = descripcion,
                                };

                                _listaDeParametros.Add(lecturas);
                            }
                        }
                    }
                    connection.Close();
                }
                return _listaDeParametros;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }    
}
