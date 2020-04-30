using EmpresaDominio.Entidades.Negocio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaDominio.Servicios
{
    public interface IEmpresaServicio
    {
        Task<Empresa> crear(Empresa modelo);
        Task<List<Empresa>> obtenerTodos();
        Task<Empresa> obtenerPorId(Guid id);
        Task<Empresa> actualizar(Empresa modelo);
        Task<bool> eliminar(Guid id);
    }
}
