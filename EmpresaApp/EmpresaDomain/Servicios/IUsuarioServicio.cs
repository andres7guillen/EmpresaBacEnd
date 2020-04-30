using EmpresaDominio.Entidades.Negocio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaDominio.Servicios
{
    public interface IUsuarioServicio
    {
        Task<Usuario> crear(Usuario modelo);
        Task<Usuario> obtenerPorId(Guid Id);
        Task<List<Usuario>> obtenerTodos();
        Task<Usuario> actualizar(Usuario modelo);
        Task<bool> eliminar(Guid Id);
        Task<bool> existeUsuarioPorEmail(string email);
        Task<List<Usuario>> obtenerPorEmpresaId(Guid empresaId);
    }
}
