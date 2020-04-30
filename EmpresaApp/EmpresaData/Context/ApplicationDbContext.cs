using EmpresaDominio.Entidades.Negocio;
using EmpresaDominio.Entidades.Seguridad;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpresaData.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, UserRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoIdentificacion> TiposIdentificacion { get; set; }
        public DbSet<Empresa> Empresas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Empresa>().HasMany(e => e.Usuarios).WithOne(u => u.Empresa);
        }

    }
}
