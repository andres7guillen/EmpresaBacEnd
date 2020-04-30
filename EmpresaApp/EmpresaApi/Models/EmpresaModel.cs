using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaApi.Models
{
    public class EmpresaModel
    {
        public string Id { get; set; }
        [StringLength(100)]
        public string RazonSocial { get; set; }
        [StringLength(50)]
        public string Nit { get; set; }
        public List<UsuarioModel> Usuarios { get; set; }
    }
}
