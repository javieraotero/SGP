
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSO.SGP.EntidadesDeNegocio.CESIDA
{
    // CustomView
    public class ALTA_COEFICIENTE_DEV
    {
        public int ID_PERSONA { get; set; }
        public int ID_DESIGNACION { get; set; }
        public int TIPO_COEFICIENTE { get; set; }
        public int NRO_CONVENIO { get; set; }
        public int PORCENTAJE_COEFICIENTE { get; set; }
        public decimal VALOR_COEFICIENTE { get; set; }
        public DateTime FECHA_VIGENCIA_DESDE { get; set; }
        public DateTime? FECHA_VIGENCIA_HASTA { get; set; }
    }
}

