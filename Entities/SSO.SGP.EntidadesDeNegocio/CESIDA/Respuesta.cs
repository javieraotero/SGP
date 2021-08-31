
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSO.SGP.EntidadesDeNegocio.CESIDA
{

    // CustomView
    public class Respuesta
    {
        public string mensaje { get; set; }
        public int codOperacion { get; set; }
        public dynamic objeto { get; set; }
        public string nroLote { get; set; }
        public string datosLote { get; set; }
    }
}

