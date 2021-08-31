	
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSO.SGP.EntidadesDeNegocio
{

// CustomView
public class FacturasCustom
	{

        public FacturasCustom() {
            this.Asignacion = new List<AsignacionCustom>();
        }

		public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Proveedor { get; set; }
        public decimal Importe { get; set; }
        public string Descripcion { get; set; }
        public int Identificador { get; set; }
        public string Numero { get; set; }
        public List<AsignacionCustom> Asignacion { get; set; }
    }

    public class AsignacionCustom {
        public string Numero { get; set; }
        public string Partida { get; set; }
        public decimal Importe { get; set; }
    }

}
	
	