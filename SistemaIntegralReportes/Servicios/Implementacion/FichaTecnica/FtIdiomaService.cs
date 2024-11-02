using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.DTO.FichaTecnica;
using SistemaIntegralReportes.Servicios.Contrato.FichaTecnica;

namespace SistemaIntegralReportes.Servicios.Implementacion.FichaTecnica
{
    public class FtIdiomaService : IFtIdioma
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;


        public FtIdiomaService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("SqlTestConection");
        }

        public async Task<List<IdiomaDTO>> Lista()
        {
            List<IdiomaDTO> listaMarcas = new List<IdiomaDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlEditar = _configuration.GetSection("FichaTecnica:FtListarIdiomas").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlEditar, connection))
                    {
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                listaMarcas.Add(new IdiomaDTO
                                {
                                    IdIdioma = reader.GetInt32(reader.GetOrdinal("idIdioma")),
                                    Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                                    Descripcion = reader.GetString(reader.GetOrdinal("descripcion"))
                                });
                            }
                        }
                    }
                }

                return listaMarcas;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de marcas", ex);
            }
        }

        public Task<IdiomaDTO> Crear(IdiomaDTO modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Editar(IdiomaDTO modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

      
    }
}
