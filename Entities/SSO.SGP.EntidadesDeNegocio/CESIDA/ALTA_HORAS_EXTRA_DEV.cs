
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSO.SGP.EntidadesDeNegocio.CESIDA
{

    // CustomView
    public class ALTA_ANTIGUEDAD_RECONOCIDA_DEV
    {

        public string ID_PERSONA { get; set; }
        public string NRO_CONVENIO { get; set; }
        public string ANOS { get; set; }
        public string MESES { get; set; }
        public string DIAS { get; set; }
        public DateTime FECHA_VIGENCIA_DESDE { get; set; }

    }
}

