
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSO.SGP.EntidadesDeNegocio.CESIDA
{

    // CustomView
    public class CAMBIO_SITUACION_REVISTA_AGENTE
    {

        public string ID_DESIGNACION { get; set; }
        public string NRO_LEGAJO { get; set; }
        public string TIPO_PLANTA { get; set; }  
        //public DateTime FECHA_APROBACION { get; set; }
        public string FECHA_DESDE { get; set; }

    }
}

