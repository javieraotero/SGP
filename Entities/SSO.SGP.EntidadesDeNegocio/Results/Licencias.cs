using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.SGP.EntidadesDeNegocio.Results
{
    public class LicenciasResult
    {

        public int Id { get; set; }
        public int Id_Agente { get; set; }
        public string Agente { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public string Licencia { get; set; }
        public int Dias { get; set; }
        public bool Aprobada { get; set; }
        public DateTime? FechaAprobada { get; set; }
        public bool Desaprobada { get; set; }
        public bool Pendiente { get; set; }
        public int? Subrogante { get; set; }
        public string cargo { get; set; }
        public string organismo { get; set; }

        public int? agente_aprueba { get; set; }
        public int? viene_de { get; set; }
        public int? Id_Cargo { get; set; }

        public List<LicenciasAgentesAprobaciones> Aprobaciones { get; set; }

    }

    public class LicenciasAgentesAprobacionesResult { 
    
        public DateTime Fecha { get; set; }
        public string Agente { get; set; }
    
    }


    public class LicenciasAgentesAprobacionesDetalleResult
    {

        public DateTime? Fecha { get; set; }
        public string Agente { get; set; }

    }
}
