using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSO.SGP.Web.Models
{
    public class NotificacionesModel
    {
        public int? Organismo{ get; set; }
        public string Titulo { get; set; }
        public string Mensaje { get; set; }
        public string Enlace { get; set; } 
    }
}