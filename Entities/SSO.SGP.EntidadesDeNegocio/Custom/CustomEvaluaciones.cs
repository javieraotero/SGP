	
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSO.SGP.EntidadesDeNegocio
{

    // CustomView
    public class CustomEvaluaciones
    {
        public int id { get; set; }
        public List<PreguntasCustom> preguntas { get; set; }
        //public
    }

    public class PreguntasCustom {
        public int id { get; set; }
        public string pregunta { get; set; }
        public int orden { get; set; }
        public bool activa { get; set; }
        public IEnumerable<RespuestasCustom> respuestas { get; set; }
    }

    public class RespuestasCustom {
        public int id { get; set; }
        public string respuesta { get; set; }
        public bool es_correcta { get; set; }
        public bool activa { get; set; }
    }

    public class RespuestasInscripto
    {
        public int id { get; set; }
        public int pregunta { get; set; }
        public int respuesta { get; set; }
    }


}

