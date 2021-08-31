using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
    public class UsuariosView
    {
        [Display(Name = "Id", Order = 0, AutoGenerateField=false)]
        public int Id { get; set; }
        [Display(Name = "Nombre", Order = 25)]
        public string Nombre { get; set; }
        //[Display(Name = "Usuario", Order = 25)]
        //public string Usuario { get; set; }
        [Display(Name = "Login", Order = 25)]
        public string Login { get; set; }       
        [Display(Name = "Activo", Order = 5)]
        public string Activo { get; set; }
        [Display(Name = "Roles", Order = 35)]
        public string Roles { get; set; }
    }
}
