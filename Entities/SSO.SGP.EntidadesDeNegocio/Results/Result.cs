using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.SGP.EntidadesDeNegocio.Results
{
    public class Result
    {
        public bool state { get; set; }
        public string message { get; set; }
        public string exception { get; set; }
        public int id { get; set; }
        public object objeto { get; set; } 
    }
}
