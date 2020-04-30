using EmpresaDominio.Entidades.Negocio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaDominio.Repositorios
{
    public interface IEmpresaRepositorio
    {
        Task<Empresa> crear(Empresa modelo);
        Task<List<Empresa>> obtenerTodos();
        Task<Empresa> obtenerPorId(Guid id);
        Task<Empresa> actualizar(Empresa modelo);
        Task<bool> eliminar(Guid id);
    }
}
