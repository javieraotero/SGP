
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSO.SGP.EntidadesDeNegocio.CESIDA
{
    // CustomView
    public class SUBROGACION_AGENTE_DEV
    {
        public string ID_DESIGNACION { get; set; }
        public int? NRO_LEGAJO { get; set; }
        public int NRO_RAMA { get; set; }
        public int NRO_CATEGORIA { get; set; }
        public DateTime FECHA_VIGENCIA_DESDE { get; set; }
        public DateTime? FECHA_VIGENCIA_HASTA { get; set; }
        public int DIAS_LABORABLES { get; set; }
    }
}

