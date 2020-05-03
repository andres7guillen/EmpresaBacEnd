using EmpresaData.Context;
using EmpresaDominio.Entidades.DTO;
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

        public async Task<List<UsuarioDTO>> obtenerPorEmpresaId(Guid empresaId)
        {
            return await _context.Usuarios.Where(u => u.EmpresaId == empresaId)
                .Select(u => new UsuarioDTO()
                {
                    apellido = u.Apellido,
                    correoElectronico = u.CorreoElectronico,
                    empresa = u.Empresa.RazonSocial,
                    empresaId = u.EmpresaId.ToString(),
                    id = u.Id.ToString(),
                    nombre = u.Nombre,
                    numeroIdentificacion = u.NumeroIdentificacion,
                    tipoIdentificacion = u.TipoIdentificacion.Descripcion,
                    tipoIdentificacionId = u.TipoIdentificacionId.ToString()
                })
                .ToListAsync();
        }

        public async Task<UsuarioDTO> obtenerPorId(Guid id)
        {
            var usuario = await _context.Usuarios
                .Include(u => u.TipoIdentificacion)
                .Include(u => u.Empresa)
                .FirstOrDefaultAsync(u => u.Id == id);
            return new UsuarioDTO()
            {
                apellido = usuario.Apellido,
                correoElectronico = usuario.CorreoElectronico,
                empresa = usuario.Empresa.RazonSocial,
                id = usuario.Id.ToString(),
                nombre = usuario.Nombre,
                numeroIdentificacion = usuario.NumeroIdentificacion,
                tipoIdentificacion = usuario.TipoIdentificacion.Descripcion
            };
        }
        public async Task<List<UsuarioDTO>> obtenerTodos()
        {
            return await _context.Usuarios
                .Select(u => new UsuarioDTO()
                {
                    apellido = u.Apellido,
                    correoElectronico = u.CorreoElectronico,
                    empresa = u.Empresa.RazonSocial,
                    empresaId = u.EmpresaId.ToString(),
                    id = u.Id.ToString(),
                    nombre = u.Nombre,
                    numeroIdentificacion = u.NumeroIdentificacion,
                    tipoIdentificacion = u.TipoIdentificacion.Descripcion,
                    tipoIdentificacionId = u.TipoIdentificacionId.ToString()
                })
                .ToListAsync();

        }
    }
}
