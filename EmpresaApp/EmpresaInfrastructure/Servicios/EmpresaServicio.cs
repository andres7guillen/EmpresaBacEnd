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
    public class EmpresaServicio : IEmpresaServicio
    {
        private readonly IEmpresaRepositorio _repositorio;
        private readonly IUsuarioServicio _usuarioServicio;

        public EmpresaServicio(IEmpresaRepositorio repositorio, IUsuarioServicio usuarioServicio)
        {
            _repositorio = repositorio;
            _usuarioServicio = usuarioServicio;
        }

        public async Task<Empresa> actualizar(Empresa modelo) => await _repositorio.actualizar(modelo);

        public async Task<Empresa> crear(Empresa modelo) => await _repositorio.crear(modelo);

        public async Task<bool> eliminar(Guid id)
        {
            try
            {
                var empresa = await _repositorio.obtenerEmpresaPorId(id);

                foreach (var usuario in empresa.Usuarios)
                {
                    if (true)
                    {
                        await _usuarioServicio.eliminar(usuario.Id);
                        break;
                    }
                    
                }


                return await _repositorio.eliminar(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Empresa> obtenerEmpresaPorId(Guid id) => await _repositorio.obtenerEmpresaPorId(id);

        public async Task<EmpresaDTO> obtenerPorId(Guid id) => await _repositorio.obtenerPorId(id);

        public async Task<List<EmpresaDTO>> obtenerTodos() => await _repositorio.obtenerTodos();
    }
}
