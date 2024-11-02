using AutoMapper;
using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.DTO.Abasto;
using SistemaIntegralReportes.DTO.Cajas;
using SistemaIntegralReportes.Servicios.Contrato.Cajas;
using System.Data;

namespace SistemaIntegralReportes.Servicios.Implementacion.Cajas
{
    public class IdentificacionDeCajasService : IIdentificacionDeCajas
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;


        public IdentificacionDeCajasService(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("InnovaProduccion");
            _mapper = mapper;
        }       

        public async Task<IdentificadorDeCajasDTO> getLecturaDeCaja(string codigoDeCaja)
        {
            IdentificadorDeCajasDTO _resultadoDeBusqueda = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlBusquedaDeCaja = _configuration.GetSection("SeccionCajasAndroid:IdentificadorDeCajas").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlBusquedaDeCaja, connection))
                    {

                        command.Parameters.AddWithValue("@codigoDeCaja", codigoDeCaja);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Int32 idCaja = reader.GetInt32(reader.GetOrdinal("ID"));
                                Int32 numero = reader.GetInt32(reader.GetOrdinal("NUMERO"));
                                string codigoDeCajas = reader.GetString(reader.GetOrdinal("CODIGO_CAJA"));
                                Int32 piezas = reader.GetInt32(reader.GetOrdinal("PIEZAS"));
                                DateTime prday = reader.GetDateTime(reader.GetOrdinal("PRDAY"));
                                DateTime regtime = reader.GetDateTime(reader.GetOrdinal("REGTIME"));
                                string codigoProducto = reader.GetString(reader.GetOrdinal("CODIGO_PRODUCTO"));
                                string estacion = reader.GetString(reader.GetOrdinal("Estacion"));
                                Int32 idEtiqueta = reader.GetInt32(reader.GetOrdinal("ID_ETIQUETA"));
                                string etiqueta = reader.GetString(reader.GetOrdinal("ETIQUETA"));
                                int estado = reader.GetInt16(reader.GetOrdinal("ESTADO"));
                                int situacion = reader.GetInt16(reader.GetOrdinal("SITUACION"));
                                float peso = reader.GetFloat(reader.GetOrdinal("PESO"));
                                float tara = reader.GetFloat(reader.GetOrdinal("TARA"));
                                string fechaFaenaCorte = reader.GetString(reader.GetOrdinal("FECHA_FAENA_CORTE"));
                                string fechaFaenaCaja = reader.GetString(reader.GetOrdinal("FECHA_FAENA_CAJA"));
                                string nombreDeProducto = reader.GetString(reader.GetOrdinal("NOMBRE_DE_PRODUCTO"));


                                string stringEstado = "";
                                switch (estado)
                                {
                                    case 1:
                                        stringEstado = "Abierta";
                                        break;
                                    case 2:
                                        stringEstado = "Abierta Manual";
                                        break;
                                    case 3:
                                        stringEstado = "Cerrada";
                                        break;
                                    case 4:
                                        stringEstado = "Cerrada Manual";
                                        break;
                                    default:
                                        stringEstado = "N/D";
                                        break;
                                }

                                string stringRegistro = "";

                                switch (situacion)
                                {
                                    case 1:
                                        stringRegistro = "Normal";
                                        break;
                                    case 2:
                                        stringRegistro = "SinItems";
                                        break;
                                    case 3:
                                        stringRegistro = "Pendiente";
                                        break;
                                    case 4:
                                        stringRegistro = "Eliminada";
                                        break;
                                    case 5:
                                        stringRegistro = "Invalida";
                                        break;
                                    case 6:
                                        stringRegistro = "Comprimida";
                                        break;
                                    case 7:
                                        stringRegistro = "Consumida";
                                        break;
                                    case 8:
                                        stringRegistro = "Regresada";
                                        break;
                                    default:
                                        stringRegistro = "N/D";
                                        break;
                                }


                                _resultadoDeBusqueda = new IdentificadorDeCajasDTO
                                {
                                    Id = idCaja,
                                    Numero = numero,
                                    CodigoCaja = codigoDeCajas,
                                    Piezas = piezas,
                                    Prday = prday.ToString("yyyy-MM-dd"),
                                    Regtime = regtime.ToString("yyyy-MM-dd HH:mm"),
                                    CodigoProducto = codigoProducto,
                                    Estacion = estacion,
                                    IdEtiqueta = idEtiqueta,
                                    Etiqueta = etiqueta,
                                    Estado = stringEstado, 
                                    Situacion = stringRegistro,
                                    Peso = peso,
                                    Tara = tara,
                                    FechaFaenaCorte = fechaFaenaCorte,
                                    FechaFaenaCaja =  fechaFaenaCaja,
                                    NombreDeProducto = nombreDeProducto,
                                };
                            }
                        }
                    }
                    connection.Close();
                }
                return _resultadoDeBusqueda;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
