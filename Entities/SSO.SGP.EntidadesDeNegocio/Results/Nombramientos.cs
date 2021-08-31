using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.SGP.EntidadesDeNegocio.Results
{
    public class NombramientosResult
    {

        public int Id { get; set; }
        public string Cargo { get; set; }
        public DateTime Desde { get; set; }
        public string SituacionRevista { get; set; }
        public string Organismo { get; set; }
        public DateTime UltimoAscenso { get; set; }

    }
}
