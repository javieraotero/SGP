using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.SGP.EntidadesDeNegocio.Results
{
    public class IncidenciasResult
    {
        public string token_dispositivo { get; set; }
        public string titulo { get; set; }
        public string mensaje { get; set; }
        public string nombre { get; set; }
        public string nombre_usuario { get; set; }
    }
}
