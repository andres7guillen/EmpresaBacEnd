using EmpresaData.Context;
using EmpresaDominio.Entidades.DTO;
using EmpresaDominio.Entidades.Negocio;
using EmpresaDominio.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Empresa> obtenerEmpresaPorId(Guid id)
        {
            return await _context.Empresas
                .Include(e => e.Usuarios)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<EmpresaDTO> obtenerPorId(Guid id)
        {
            var empresa = await _context.Empresas
                .Include(e => e.Usuarios)
                .FirstOrDefaultAsync(e => e.Id == id);
            return new EmpresaDTO()
            {
                Id = empresa.Id.ToString(),
                Nit = empresa.Nit,
                RazonSocial = empresa.RazonSocial,
                Usuarios = empresa.Usuarios.Count
            };                
        }

        public async Task<List<EmpresaDTO>> obtenerTodos()
        {
            return await _context.Empresas
                .Select(e => new EmpresaDTO()
                {
                    Id = e.Id.ToString(),
                    Nit = e.Nit,
                    RazonSocial = e.RazonSocial,
                    Usuarios = e.Usuarios.Count
                })
                .ToListAsync();
        }
    }
}
