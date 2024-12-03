
using SistemaIntegralReportes.AplicacionDePedidos;
using SistemaIntegralReportes.AplicacionDePedidos.Entidades;

namespace SistemaIntegralReportes.Servicios.Contrato.SistemaDePedidos
{
    public interface ISpUsuarioSolicitante
    {

        Task<List<UsuarioSolicitante>> ListaDeUsuarios();

        Task<UsuarioSolicitante> Crear(UsuarioSolicitante modelo);

        Task<bool> Editar(UsuarioSolicitante modelo);

        Task<UsuarioSolicitante> BuscarPorNombre(string nombre);
    }
}
