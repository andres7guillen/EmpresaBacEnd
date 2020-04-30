using EmpresaDominio.Repositorios;
using EmpresaDominio.Servicios;
using EmpresaInfrastructura.Repositorios;
using EmpresaInfrastructura.Servicios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaApi.Utility
{
    public static class ServiciosExtensiones
    {
        public static IServiceCollection RegistroServiciosNegocio(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioServicio, UsuarioServicio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<ITipoIdentificacionServicio, TipoIdentificacionServicio>();
            services.AddScoped<ITipoIdentificacionRepositorio, TipoIdentificacionRepositorio>();
            services.AddScoped<IEmpresaServicio, EmpresaServicio>();
            services.AddScoped<IEmpresaRepositorio, EmpresaRepositorio>();

            return services;
        }
    }
}
