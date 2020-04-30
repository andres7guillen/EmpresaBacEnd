using EmpresaDominio.Entidades.Negocio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaDominio.Repositorios
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario> crear(Usuario modelo);
        Task<Usuario> obtenerPorId(Guid id);
        Task<List<Usuario>> obtenerTodos();
        Task<Usuario> actualizar(Usuario modelo);
        Task<bool> eliminar(Guid id);
        Task<bool> existeUsuarioPorEmail(string email);
        Task<List<Usuario>> obtenerPorEmpresaId(Guid empresaId);
    }
}
