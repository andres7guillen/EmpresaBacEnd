using EmpresaData.Context;
using EmpresaDominio.Entidades.Negocio;
using EmpresaDominio.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaInfrastructura.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> actualizar(Usuario modelo)
        {
            _context.Usuarios.Update(modelo);
            await _context.SaveChangesAsync();
            return modelo;
        }
        public async Task<Usuario> crear(Usuario modelo)
        {
            try
            {
                await _context.Usuarios.AddAsync(modelo);
                await _context.SaveChangesAsync();
                return modelo;
            }
            catch (Exception e)
            {
                throw e;
            }            
        }
        public async Task<bool> eliminar(Guid id)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
            _context.Usuarios.Remove(usuario);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> existeUsuarioPorEmail(string email)
        {
            try
            {
                return await _context.Usuarios.AnyAsync(u => u.CorreoElectronico == email);
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        public async Task<List<Usuario>> obtenerPorEmpresaId(Guid empresaId)
        {
            return await _context.Usuarios.Where(u => u.EmpresaId == empresaId).ToListAsync();
        }

        public async Task<Usuario> obtenerPorId(Guid id)
        {
            return await _context.Usuarios
                .Include(u => u.Empresa)
                .FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<List<Usuario>> obtenerTodos()
        {
            return await _context.Usuarios
                .Include(u => u.Empresa)
                .ToListAsync();
        }
    }
}
