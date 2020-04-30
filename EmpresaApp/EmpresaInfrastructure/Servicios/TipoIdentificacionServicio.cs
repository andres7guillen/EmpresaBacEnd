using EmpresaDominio.Entidades.Negocio;
using EmpresaDominio.Repositorios;
using EmpresaDominio.Servicios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaInfrastructura.Servicios
{
    public class TipoIdentificacionServicio : ITipoIdentificacionServicio
    {
        private readonly ITipoIdentificacionRepositorio _repositorio;
        public TipoIdentificacionServicio(ITipoIdentificacionRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<TipoIdentificacion>> obtenerTodos() => await _repositorio.obtenerTodos();
    }
}
