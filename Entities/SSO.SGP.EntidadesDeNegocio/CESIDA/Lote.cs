
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSO.SGP.EntidadesDeNegocio.CESIDA
{

    // CustomView
    public class Lote
    {
        public string sistema { get; set; }
        public string clave { get; set; }
        public string nombreLote { get; set; }
        public string nombreProceso { get; set; }
        public string datosLote { get; set; }
        //public string accion { get; set; }
        //public string incluyeRegistro { get; set; }
        public string parametrosProceso { get; set; }
    }
}

