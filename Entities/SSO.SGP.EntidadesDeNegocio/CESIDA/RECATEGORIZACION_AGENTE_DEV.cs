
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSO.SGP.EntidadesDeNegocio.CESIDA
{

    // CustomView
    public class RECATEGORIZACION_AGENTE_DEV
    {
        public string ID_DESIGNACION { get; set; }
        public string NRO_LEGAJO { get; set; }
        public string NRO_CONVENIO { get; set; }
        public string NRO_RAMA { get; set; }
        public string NRO_CATEGORIA { get; set; }
        //public string CODIGO_JURISDICCION { get; set; }
        //public string NUMERO_UNIDAD_ORG { get; set; }
        //public DateTime FECHA_APROBACION { get; set; }
        public string FECHA_VIGENCIA_DESDE { get; set; }
    }

}

