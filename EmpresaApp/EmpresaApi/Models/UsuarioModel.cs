using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaApi.Models
{
    public class UsuarioModel
    {
        public string Id { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(50)]
        public string Apellido { get; set; }
        public Guid TipoIdentificacionId { get; set; }
        public TipoIdentificacionModel TipoIdentificacion { get; set; }
        [StringLength(100)]
        public string CorreoElectronico { get; set; }
        public Guid EmpresaId { get; set; }
        public EmpresaModel Empresa { get; set; }
    }
}
