using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.SGP.EntidadesDeNegocio.Results
{
    public class FacturasResult
    {

        public int Id { get; set; }
        public decimal Importe { get; set; }
        public DateTime Fecha { get; set; }
        public string Proveedor { get; set; }
        public bool EstaAsignada { get; set; }
        public string NumeroDeFactura { get; set; }

    }
}
