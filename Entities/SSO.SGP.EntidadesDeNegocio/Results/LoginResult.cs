using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.SGP.EntidadesDeNegocio.Results
{
    public class LoginResult
    {
        
        public int usuario_id { get; set; }
        public string usuario { get; set; }
        public int organismo { get; set; }
        public string organismo_descripcion { get; set; }
        public bool es_funcionario { get; set; }
        public int cargo { get; set; }
        public string email_agente { get; set; }
        public bool mp { get; set; }
        public bool habilita_aprobar_licencia { get; set; }

    }
}
