using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmpresaDominio.Entidades.Negocio
{
    public class TipoIdentificacion
    {
        public Guid Id { get; set; }
        [StringLength(2)]
        public string Descripcion { get; set; }
    }
}
