using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSO.SGP.EntidadesDeNegocio
{

    // CustomView
    //public class LicenciasResult
    //{

    //    public int id { get; set; }
    //    public string descripcion { get; set; }
    //    public DateTime desde { get; set; }
    //    public DateTime hasta { get; set; }
    //    public int id_licencia { get; set; }

    //}

    //public class AgentesResult {

    //    public int id { get; set; }
    //    public string nombre { get; set; }
    //    public string apellido { get; set; }
    //    public string legajo { get; set; }
    //    public string cargo { get; set; } 
    //    public int id_cargo { get; set; }
    //    public DateTime fechaingreso { get; set; }
    //    public string organismo { get; set; }
    //    public int id_organismo { get; set; }

    //}

    public class PlantaDePersonalResult
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int? Presupuesto { get; set; }
        public int? PlantaPermanente { get; set; }
        public int? Vacantes { get; set; }
        public int? Contratados { get; set; }
        public int? Saldo { get; set; }
        public int? Sustitutos { get; set; }

    }

}
	
	