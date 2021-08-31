using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSO.SGP.Web.Models
{
    public class FacturasImputadasModel
    {
        public int Partida { get; set; }
        public int Division { get; set; }
        public decimal Importe { get; set; } 
    }

    public class FacturasAsignadasModel
    {
        public int Partida { get; set; }
        public int Division { get; set; }
        public decimal Importe { get; set; }
        public int Id { get; set; }
    }
}