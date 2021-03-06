﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmpresaDominio.Entidades.Seguridad
{
    public class UserInfo
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        //Extra
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(50)]
        public string Apellido { get; set; }
        public Guid TipoIdentificacionId { get; set; }
        public Guid EmpresaId { get; set; }
        [StringLength(30)]
        public string NumeroIdentificacion { get; set; }
        //public string CorreoElectronico { get; set; }
    }
}
