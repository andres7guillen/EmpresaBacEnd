using EmpresaData.Context;
using EmpresaDominio.Entidades.Negocio;
using EmpresaDominio.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaInfrastructura.Repositorios
{
    public class TipoIdentificacionRepositorio : ITipoIdentificacionRepositorio
    {
        private readonly ApplicationDbContext _context;

        public TipoIdentificacionRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<TipoIdentificacion>> obtenerTodos()
        {
            return await _context.TiposIdentificacion.ToListAsync();
        }
    }
}
