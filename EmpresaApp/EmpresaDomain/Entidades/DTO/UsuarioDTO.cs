using EmpresaDominio.Entidades.Negocio;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpresaDominio.Entidades.DTO
{
    public class UsuarioDTO
    {
    public string id { get; set; }
    public string nombre { get; set; }
    public string apellido { get; set; }
    public string tipoIdentificacionId { get; set; }
    public string tipoIdentificacion { get; set; }
    public string correoElectronico { get; set; }
    public string empresaId { get; set; }
    public string empresa { get; set; }
    public string numeroIdentificacion { get; set; }
    }
}
