
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSO.SGP.EntidadesDeNegocio.CESIDA
{

    // CustomView
    public class ALTA_TITULO_AGENTE_DEV
    {
        public int ID_PERSONA { get; set; }
        public string COD_TITULO { get; set; }
        public DateTime FECHA_VIGENCIA_DESDE { get; set; }
    }
}

