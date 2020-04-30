using EmpresaDominio.Entidades.Negocio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaDominio.Servicios
{
    public interface ITipoIdentificacionServicio
    {
        Task<List<TipoIdentificacion>> obtenerTodos();
    }
}
