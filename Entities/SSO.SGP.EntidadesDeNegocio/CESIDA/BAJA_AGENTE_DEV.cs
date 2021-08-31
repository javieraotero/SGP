
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSO.SGP.EntidadesDeNegocio.CESIDA
{

    // CustomView
    public class BAJA_AGENTE_DEV
    {

        public string ID_DESIGNACION { get; set; }
        public string NUMERO_LEGAJO { get; set; }
        public DateTime FECHA_VIGENCIA_DESDE { get; set; }

    }
}

