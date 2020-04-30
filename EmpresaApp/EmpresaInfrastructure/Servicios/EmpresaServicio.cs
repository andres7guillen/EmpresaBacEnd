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

        public EmpresaServicio(IEmpresaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<Empresa> actualizar(Empresa modelo) => await _repositorio.actualizar(modelo);

        public async Task<Empresa> crear(Empresa modelo) => await _repositorio.crear(modelo);

        public async Task<bool> eliminar(Guid id) => await _repositorio.eliminar(id);

        public async Task<Empresa> obtenerPorId(Guid id) => await _repositorio.obtenerPorId(id);

        public async Task<List<Empresa>> obtenerTodos() => await _repositorio.obtenerTodos();
    }
}
