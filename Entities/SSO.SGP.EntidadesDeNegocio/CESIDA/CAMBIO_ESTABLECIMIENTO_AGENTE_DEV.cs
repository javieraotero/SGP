
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSO.SGP.EntidadesDeNegocio.CESIDA
{

    // CustomView
    public class CAMBIO_ESTABLECIMIENTO_AGENTE_DEV
    {

        public string ID_DESIGNACION { get; set; }
        public string NRO_LEGAJO { get; set; }
        public string NRO_UBICACION { get; set; }  
        //public DateTime FECHA_APROBACION { get; set; }
        public DateTime FECHA_VIGENCIA_DESDE { get; set; }

    }
}

