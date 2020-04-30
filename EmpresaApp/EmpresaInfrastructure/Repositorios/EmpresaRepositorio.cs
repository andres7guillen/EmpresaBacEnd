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
    public class EmpresaRepositorio : IEmpresaRepositorio
    {
        private ApplicationDbContext _context;

        public EmpresaRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Empresa> actualizar(Empresa modelo)
        {
            _context.Empresas.Update(modelo);
            await _context.SaveChangesAsync();
            return modelo;
        }

        public async Task<Empresa> crear(Empresa modelo)
        {
            modelo.Id = Guid.NewGuid();
            await _context.Empresas.AddAsync(modelo);
            await _context.SaveChangesAsync();
            return modelo;
        }

        public async Task<bool> eliminar(Guid id)
        {
            var empresa = await _context.Empresas.FirstOrDefaultAsync(e => e.Id == id);
            _context.Empresas.Remove(empresa);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Empresa> obtenerPorId(Guid id)
        {
            return await _context.Empresas.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Empresa>> obtenerTodos()
        {
            return await _context.Empresas.ToListAsync();
        }
    }
}
