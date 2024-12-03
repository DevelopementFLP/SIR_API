using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.DTO.FichaTecnica.CrearPlantillas;
using SistemaIntegralReportes.Servicios.Contrato.FichaTecnica;
using System.Drawing.Imaging;

namespace SistemaIntegralReportes.Servicios.Implementacion.FichaTecnica
{
    public class FtImagenService : IFtImagenPlantilla
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public FtImagenService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlTestConection");
            _configuration = configuration;
        }

        public async Task<List<ImagenesPlantillaDTO>> BuscarImagenPorProducto(string codigoDeProducto)
        {
            var imagenes = new List<ImagenesPlantillaDTO>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string sqlGetImagenFichaTecnica = _configuration.GetSection("FichaTecnica:FtBuscarImagenFichaTecnica").Value;

                using (SqlCommand command = new SqlCommand(sqlGetImagenFichaTecnica, connection))
                {
                    command.Parameters.AddWithValue("@codigoDeProducto", "%" + codigoDeProducto + "%");

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var imagen = new ImagenesPlantillaDTO
                            {
                                IdFoto = reader.GetInt32(0),
                                codigoDeProducto = reader.GetString(1),
                                SeccionDeImagen = reader.GetInt32(2),
                                ContenidoImagen = Convert.ToBase64String((byte[])reader["imagen"])
                            };

                            imagenes.Add(imagen);
                        }
                    }
                }
            }

            return imagenes.OrderBy(seccion => seccion.SeccionDeImagen).ToList();
        }


        public async Task<ImagenesPlantillaDTO> Crear(string codigoDeProducto, int seccionDeImagen, byte[] imagenBytes)
        {
            // Crear un nuevo objeto de ImagenesPlantillaDTO
            var modelo = new ImagenesPlantillaDTO
            {
                SeccionDeImagen = seccionDeImagen,
                codigoDeProducto = codigoDeProducto
            };

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string sqlInsertarImagen = _configuration.GetSection("FichaTecnica:FtCrearImagenes").Value.ToString();

                using (SqlCommand command = new SqlCommand(sqlInsertarImagen, connection))
                {
                    command.Parameters.AddWithValue("@codigoDeProducto", modelo.codigoDeProducto);
                    command.Parameters.AddWithValue("@seccionDeImagen", modelo.SeccionDeImagen);
                    command.Parameters.AddWithValue("@imagen", imagenBytes);
                    command.Parameters.AddWithValue("@idFichaTecnica", idFichaTecnica);

                    modelo.IdFoto = (int)await command.ExecuteScalarAsync();
                }
            }

            return modelo;
        }

        public async Task<bool> Editar(ImagenesPlantillaDTO modelo, byte[] imagenBytes)
        {

            if (modelo == null || imagenBytes == null || imagenBytes.Length == 0)
            {
                return false; 
            }

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string sqlActualizarImagen = _configuration.GetSection("FichaTecnica:EditarImagenFichaTecnica").Value.ToString();

                using (SqlCommand command = new SqlCommand(sqlActualizarImagen, connection))
                {

                    command.Parameters.AddWithValue("@idFoto", modelo.IdFoto); 
                    command.Parameters.AddWithValue("@seccionDeImagen", modelo.SeccionDeImagen);
                    command.Parameters.AddWithValue("@imagen", imagenBytes); 

                    int filasAfectadas = await command.ExecuteNonQueryAsync();

                    return filasAfectadas > 0;
                }
            }
        }


        public async Task<bool> Eliminar(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string sqlEliminarImagenes = _configuration.GetSection("FichaTecnica:EditarImagenFichaTecnica").Value.ToString();


                using (SqlCommand command = new SqlCommand(sqlEliminarImagenes, connection))
                {
                    command.Parameters.AddWithValue("@codigoDeProducto", "%" + id + "%");

                    return await command.ExecuteNonQueryAsync() > 0;
                }
            }
        }

        
    }
}
