
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSO.SGP.EntidadesDeNegocio.CESIDA
{

    // CustomView
    public class RECTIFICACION_NOVEDAD
    {

        public string NOMBRE_PROCESO { get; set; }
        public string ID_NOVEDAD { get; set; }
        public string ID_PERSONA { get; set; }
        public string ID_DESIGNACION { get; set; }
        public string COMENTARIO { get; set; }

    }
}

