using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmpresaDominio.Entidades.Negocio
{
    public class Empresa
    {
        public Guid Id { get; set; }
        [StringLength(100)]
        public string RazonSocial { get; set; }
        [StringLength(50)]
        public string Nit { get; set; }
        public List<Usuario> Usuarios { get; set; }
    }
}
