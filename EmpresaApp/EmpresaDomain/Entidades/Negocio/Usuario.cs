using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmpresaDominio.Entidades.Negocio
{
    public class Usuario
    {
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(50)]
        public string Apellido { get; set; }
        public Guid TipoIdentificacionId { get; set; }
        public TipoIdentificacion TipoIdentificacion { get; set; }
        [StringLength(100)]
        public string CorreoElectronico { get; set; }
        public Guid EmpresaId { get; set; }
        public Empresa Empresa { get; set; }

    }
}
