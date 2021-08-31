using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;

namespace SSO.SGP.EntidadesDeNegocio
{
    public enum eNotificaciones : int
    {
        success = 1,
        warning = 2,
        danger = 3,
        info = 4
    }

    public class Notificacionesadm
    {
        [Required]
        [Display(Name = "Tipo")]
        public eNotificaciones Tipo { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Display(Name = "Valor")]
        public int Valor { get; set; }
    }

    public class Query
    {

        public List<string> columnas { get; set; }
        public List<List<object>> resultado { get; set; }

    }

    public class PersonaTurnosWeb { 
    
        public int id_persona { get; set; }
        public int id_usuario { get; set; }
        public int cargo { get; set; }
        public string nombre { get; set; }

        public int dias_acumulados { get; set; }

    }

    public class TurnoWebResult { 
        public DateTime fecha { get; set; }
        public TimeSpan hora { get; set; }
        public bool no_es_turno { get; set; }
        public bool solo_mensaje { get; set; }
    }
}
