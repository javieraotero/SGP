	
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSO.SGP.EntidadesDeNegocio
{

    // CustomView
    public class ExpedientesClientModel
    {

        public int id { get; set; }
        public DateTime fecha { get; set; }
        public DateTime hoy { get; set; }
        public string hoy_en_letras { get; set; }
        public string caratula { get; set; }
        public string iniciador { get; set; }
        public string numero { get; set; }

        public virtual IEnumerable<ImputacionContableClient> imputaciones { get; set; }
        public virtual IEnumerable<FacturasClient> facturas { get; set; }

    }

    public class ImputacionContableClient
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public int operacion { get; set; }
        public int anio_contable { get; set; }
        public string fecha_letras { get; set; }
        public string total_en_letras { get; set; }
        public decimal total { get; set; }

        public virtual IEnumerable<DetalleImputacionClient> detalle { get; set; }
        public virtual IEnumerable<FacturasClient> facturas { get; set; }
    }

    public class DetalleImputacionClient {

        public int id { get; set; }
        public decimal importe { get; set; }
        public string partida { get; set; }
        public string division { get; set; }
        public string numero_partida { get; set; }
        public string nombre_partida { get; set; }

    }

    public class FacturasClient {

        public int id { get; set; }
        public string nombre_proveedor { get; set; }
        public string numero { get; set; }
        public decimal importe { get; set; }
        public string concepto { get; set; }
        public DateTime fecha { get; set; }

    }


}
	
	