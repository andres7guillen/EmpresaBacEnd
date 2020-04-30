using EmpresaDominio.Entidades.Negocio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaDominio.Repositorios
{
    public interface ITipoIdentificacionRepositorio
    {
        Task<List<TipoIdentificacion>> obtenerTodos();
        
    }
}
