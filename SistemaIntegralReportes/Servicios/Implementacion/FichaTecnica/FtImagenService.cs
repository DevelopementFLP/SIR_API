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
                    //command.Parameters.AddWithValue("@codigoDeProducto", codigoDeProducto);
                    command.Parameters.AddWithValue("@codigoDeProducto", "%" + codigoDeProducto + "%");

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var imagen = new ImagenesPlantillaDTO
                            {
                                IdFoto = reader.GetInt32(0), // Asegúrate de que la propiedad sea "Id" y no "IdFoto"
                                codigoDeProducto = reader.GetString(1),
                                SeccionDeImagen = reader.GetInt32(2),
                                ContenidoImagen = Convert.ToBase64String((byte[])reader["imagen"])
                            };

                            imagenes.Add(imagen);
                        }
                    }
                }
            }

            return imagenes;
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
                    command.Parameters.AddWithValue("@imagen", imagenBytes); // Usa el arreglo de bytes aquí

                    modelo.IdFoto = (int)await command.ExecuteScalarAsync();
                }
            }

            return modelo;
        }


        public async Task<bool> Editar(ImagenesPlantillaDTO modelo, byte[] imagenBytes)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand("UPDATE imagenes_ficha_tecnica SET seccionDeImagen = @seccionDeImagen, imagen = @imagen WHERE idFoto = @idFoto", connection))
                {
                    command.Parameters.AddWithValue("@seccionDeImagen", modelo.SeccionDeImagen);
                    command.Parameters.AddWithValue("@imagen", imagenBytes); // Ahora se guarda la nueva imagen
                    command.Parameters.AddWithValue("@idFoto", modelo.IdFoto);

                    return await command.ExecuteNonQueryAsync() > 0;
                }
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand("DELETE FROM imagenes_ficha_tecnica WHERE idFoto = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    return await command.ExecuteNonQueryAsync() > 0;
                }
            }
        }

        
    }
}
