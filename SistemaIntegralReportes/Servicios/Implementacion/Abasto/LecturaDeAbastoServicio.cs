using AutoMapper;
using Microsoft.Data.SqlClient;
using SistemaIntegralreportes.DTO;
using SistemaIntegralReportes.DTO.Abasto;
using SistemaIntegralReportes.Models.Reportes;
using SistemaIntegralReportes.Models.Reportes.ReporteAbasto;
using SistemaIntegralReportes.Servicios.Contrato.Abasto;
using System.Data;

namespace SistemaIntegralReportes.Servicios.Implementacion.Abasto
{
    public class LecturaDeAbastoServicio : ILecturaDeAbasto
    {

        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;


        public LecturaDeAbastoServicio(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("SqlTestConection");
            _mapper = mapper;
        }

        public async Task<LecturaDeAbastoDTO> GetCodigoQrFiltrado(string codigoQr)
        {

            LecturaDeAbastoDTO _lecturaFiltrada = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlBusquedaDeQr = _configuration.GetSection("SeccionAbasto:BuscarCodigoQr").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlBusquedaDeQr, connection))
                    {
                        // Agregamos el parámetro con los comodines '%' incluidos
                        command.Parameters.Add("@codigoQr", SqlDbType.NVarChar).Value = "%" + codigoQr + "%";

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime fechaDeRegistro = reader.GetDateTime(0);
                                string lecturaDeMedia = reader.GetString(1);
                                string idAnimal = reader.GetString(2);
                                string secuencial = reader.GetString(3);
                                string operacion = reader.GetString(4);
                                string usuarioLogueado = reader.GetString(7);


                                _lecturaFiltrada = new LecturaDeAbastoDTO
                                {
                                    FechaDeRegistro = fechaDeRegistro,
                                    LecturaDeMedia = lecturaDeMedia,
                                    IdAnimal = idAnimal,
                                    Secuencial = secuencial,
                                    Operacion = operacion,
                                    UsuarioLogueado = usuarioLogueado
                                };
                            }
                        }
                    }
                    connection.Close();
                }
                return _lecturaFiltrada;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<LecturaDeAbastoDTO>> GetLecturaDeAbasto()
        {

            List<LecturaDeAbastoDTO> _listaDeLecturas = new List<LecturaDeAbastoDTO>();

            string fechaDelDia = DateTime.Now.ToString("yyyyMMdd" + " 23:59:59.000");


            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlLecturaDeAbasto = _configuration.GetSection("SeccionAbasto:LecturasDeAbasto").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlLecturaDeAbasto, connection))
                    {
                        //Agrego el parametro de la consulta
                        command.Parameters.AddWithValue("@fechaDelDia", fechaDelDia);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime fechaDeRegistro = reader.GetDateTime(0);
                                string lecturaDeMedia = reader.GetString(1);
                                string idAnimal = reader.GetString(2);
                                string secuencial = reader.GetString(3);
                                string operacion = reader.GetString(4);
                                string usuarioLogueado = reader.GetString(7);                                


                                LecturaDeAbastoDTO lecturas = new LecturaDeAbastoDTO
                                {
                                    FechaDeRegistro= fechaDeRegistro,
                                    LecturaDeMedia = lecturaDeMedia,
                                    IdAnimal = idAnimal,
                                    Secuencial = secuencial,
                                    Operacion = operacion,
                                    UsuarioLogueado= usuarioLogueado
                                };

                                _listaDeLecturas.Add(lecturas);
                            }
                        }
                    }
                    connection.Close();
                }
                return _listaDeLecturas.OrderByDescending(a => a.FechaDeRegistro).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<LecturaDeAbastoDTO> InsertarLectura(string lecturaDeMedia, string operacion, string usuarioLogueado , DateTime? fechaDeFaena = null, decimal? peso = null )
        {
            LecturaDeAbastoDTO lecturaDeMediaInsert = new LecturaDeAbastoDTO();
            string parseoDeLectura = "";
            string parseoSecuencial = "";
            
               
            if (lecturaDeMedia == null) 
            {
                throw new Exception("Datos inválidos proporcionados.");
            }
            
            if(fechaDeFaena == null || peso == null)
            {
                fechaDeFaena = DateTime.Now.Date;
                peso = 0;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlInsertarLecturas = _configuration.GetSection("SeccionAbasto:InsertarLecturasDW_Prod_Abasto").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlInsertarLecturas, connection))
                    {
                        command.Parameters.AddWithValue("@lecturaDeMedia", lecturaDeMedia);
                        command.Parameters.AddWithValue("@operacion", operacion);

                        parseoDeLectura = lecturaDeMedia.Substring(22, 13);
                        command.Parameters.AddWithValue("@idAnimal", parseoDeLectura);                   
                        
                        parseoSecuencial = lecturaDeMedia.Substring(30, 4);
                        command.Parameters.AddWithValue("@secuencial", parseoSecuencial);

                        command.Parameters.AddWithValue("@peso", peso);
                        command.Parameters.AddWithValue("@fechaDeFaena", fechaDeFaena);

                        command.Parameters.AddWithValue("@usuarioLogueado", usuarioLogueado);

                        await command.ExecuteNonQueryAsync();

                        lecturaDeMediaInsert.LecturaDeMedia = lecturaDeMedia;
                        lecturaDeMediaInsert.IdAnimal = parseoDeLectura;
                        lecturaDeMediaInsert.Secuencial = parseoSecuencial;
                        lecturaDeMediaInsert.Operacion = operacion;
                        lecturaDeMediaInsert.Peso = peso;
                        lecturaDeMediaInsert.FechaDeFaena = fechaDeFaena;
                        lecturaDeMediaInsert.UsuarioLogueado = usuarioLogueado;
                    }
                }

                return lecturaDeMediaInsert;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<ListaDeLecturasAbasto>> ListarLecturasVistaAbasto(DateTime fechaDelDia)
        {
            List<ListaDeLecturasAbasto> _listaDeLecturas = new List<ListaDeLecturasAbasto>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlLecturaDeAbasto = _configuration.GetSection("SeccionAbasto:ListarLecturasDeAbasto").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlLecturaDeAbasto, connection))
                    {
                        //Agrego el parametro de la consulta
                        command.Parameters.AddWithValue("@fechaDelDia", fechaDelDia);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime fechaDeRegistro = reader.GetDateTime(0);
                                string lecturaDeMedia = reader.GetString(1);
                                string idAnimal = reader.GetString(2);
                                string tropa = reader.GetString(3);
                                string proveedor = reader.GetString(4);
                                float peso = reader.GetFloat(5);
                                DateTime fechaFaena = reader.GetDateTime(6);
                                string clasificacion = reader.GetString(7);                               
                                string secuencial = reader.GetString(8);
                                string operacion = reader.GetString(9);
                                


                                ListaDeLecturasAbasto lecturas = new ListaDeLecturasAbasto
                                {
                                    FechaDeRegistro = fechaDeRegistro.ToString("yyyy-MM-dd"),
                                    LecturaDeMedias = lecturaDeMedia,
                                    IdAnimal = idAnimal,
                                    Tropa = tropa,
                                    Proveedor = proveedor,
                                    Peso = peso,
                                    FechaDeFaena = fechaFaena.ToString("yyyy-MM-dd"),
                                    Clasificacion = clasificacion,
                                    Secuencial = secuencial,
                                    Operacion = operacion                                    
                                };

                                _listaDeLecturas.Add(lecturas);
                            }
                        }
                    }
                    connection.Close();
                }
                return _listaDeLecturas.OrderBy(a => a.FechaDeRegistro).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    }
}
