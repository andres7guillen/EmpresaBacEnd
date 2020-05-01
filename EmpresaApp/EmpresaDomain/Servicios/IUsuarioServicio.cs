using EmpresaDominio.Entidades.DTO;
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
        Task<UsuarioDTO> obtenerPorId(Guid Id);
        Task<List<UsuarioDTO>> obtenerTodos();
        Task<Usuario> actualizar(Usuario modelo);
        Task<bool> eliminar(Guid Id);
        Task<bool> existeUsuarioPorEmail(string email);
        Task<List<UsuarioDTO>> obtenerPorEmpresaId(Guid empresaId);
    }
}
