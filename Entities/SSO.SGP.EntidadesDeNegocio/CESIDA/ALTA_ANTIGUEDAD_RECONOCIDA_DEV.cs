
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSO.SGP.EntidadesDeNegocio.CESIDA
{

    // CustomView
    public class ALTA_HORAS_EXTRA_DEV
    {

        public string ID_DESIGNACION { get; set; }
        public string NUMERO_LEGAJO { get; set; }
        public DateTime FECHA_VIGENCIA_DESDE { get; set; }
        public string TIPO_HORA_EXTRA { get; set; }
        public int CANTIDAD_HORAS { get; set; }
        public int NO_LABORABLE { get; set; }

    }
}

