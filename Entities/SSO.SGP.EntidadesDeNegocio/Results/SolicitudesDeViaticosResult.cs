using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.SGP.EntidadesDeNegocio.Results
{
    public class SolicitudesDeViaticosResult
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string OrganismoSolicitante { get; set; }
        public string Motivo { get; set; }
        public DateTime FechaDeInicio { get; set; }
        public DateTime FechaDeFin { get; set; }
        public string LugarYFecha { get; set; }
        public string sFechaDeInicio { get; set; }
        public string sFechaDeFin { get; set; }
        public string MedioDeTransporte { get; set; }
        public string Destino { get; set; }
        public IEnumerable<SolicitudDeViaticosAgenteResult> Detalle { get; set; }

    }

    public class SolicitudDeViaticosAgenteResult {

        public string Nombre { get; set; }
        public string Afiliado { get; set; }
        public string Categoria { get; set; }
        public decimal Dias { get; set; }
        public decimal PesosPorDia { get; set; }
        public decimal Viatico { get; set; }
        public decimal Gastos { get; set; }
        public decimal Total { get; set; }

    }

    public class RendicionResult
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaDeInicio { get; set; }
        public DateTime FechaDeFin { get; set; }
        public string LugarYFecha { get; set; }
        public string sFechaDeInicio { get; set; }
        public string sFechaDeFin { get; set; }
        public string Destino { get; set; }
        public decimal TGastos { get; set; }
        public decimal Total { get; set; }
        public decimal Anticipo { get; set; }
        public decimal Cobrar { get; set; }
        public decimal Devolver { get; set; }
        public decimal BienesDeConsumo { get; set; }
        public decimal ServiciosNoPersonales { get; set; }
        public decimal Otros { get; set; }

        public IEnumerable<RendicionAgenteResult> Detalle { get; set; }

    }

    public class RendicionAgenteResult
    {

        public string Nombre { get; set; }
        public string Afiliado { get; set; }
        public decimal Dias { get; set; }
        public decimal PesosPorDia { get; set; }
        public decimal Viatico { get; set; }
        public decimal Gastos { get; set; }
        public decimal Total { get; set; }
        public decimal Anticipo { get; set; }
        public decimal Cobrar { get; set; }
        public decimal Devolver { get; set; }

    }

}
