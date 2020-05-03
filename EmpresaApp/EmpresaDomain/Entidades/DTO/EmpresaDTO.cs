using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmpresaDominio.Entidades.DTO
{
    public class EmpresaDTO
    {
        public string Id { get; set; }
        [StringLength(100)]
        public string RazonSocial { get; set; }
        [StringLength(50)]
        public string Nit { get; set; }
        public int Usuarios { get; set; }
    }
}
