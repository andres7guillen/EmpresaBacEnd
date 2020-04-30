using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaApi.Models
{
    public class TipoIdentificacionModel
    {
        public string Id { get; set; }
        [StringLength(2)]
        public string Descripcion { get; set; }
    }
}
