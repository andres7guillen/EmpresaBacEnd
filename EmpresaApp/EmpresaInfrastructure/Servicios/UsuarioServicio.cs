using EmpresaDominio.Entidades.DTO;
using EmpresaDominio.Entidades.Negocio;
using EmpresaDominio.Repositorios;
using EmpresaDominio.Servicios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaInfrastructura.Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IUsuarioRepositorio _repositorio;
        public UsuarioServicio(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<Usuario> actualizar(Usuario modelo) => await _repositorio.actualizar(modelo);

        public async Task<Usuario> crear(Usuario modelo) => await _repositorio.crear(modelo);

        public async Task<bool> eliminar(Guid id) => await _repositorio.eliminar(id);

        public async Task<bool> existeUsuarioPorEmail(string email) => await _repositorio.existeUsuarioPorEmail(email);

        public async Task<List<UsuarioDTO>> obtenerPorEmpresaId(Guid empresaId) => await _repositorio.obtenerPorEmpresaId(empresaId);

        public async Task<UsuarioDTO> obtenerPorId(Guid id) => await _repositorio.obtenerPorId(id);

        public async Task<List<UsuarioDTO>> obtenerTodos() => await _repositorio.obtenerTodos();
    }
}
