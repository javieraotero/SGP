using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.SGP.EntidadesDeNegocio
{
    public class SolicitudesDeViaticosAgentesCustom
    {
        public int Id { get; set; }

        public int SolicitudDeViatico { get; set; }

        public int Agente { get; set; }

        public decimal Dias { get; set; }

        public decimal ImportePorDia { get; set; }

        public decimal Subtotal { get; set; }

        public decimal ImporteGastos { get; set; }

        public decimal ImporteTotal { get; set; }

        public string AgenteDescripcion { get; set; }

        public string CargoDescripcion { get; set; }

        public int? Grupo { get; set; }

        public bool Anticipo { get; set; }

        public string Afiliado { get; set; }

    }

    public class SolicitudesDeViaticosRendicionesAgentesCustom
    {
        public int Id { get; set; }

        public int Rendicion { get; set; }

        public int Agente { get; set; }

        public decimal Dias { get; set; }

        public decimal ImportePorDia { get; set; }

        public decimal Subtotal { get; set; }

        public decimal Gastos { get; set; }

        public decimal Anticipo { get; set; }

        public string AgenteDescripcion { get; set; }

        public decimal Cobrar { get; set; }

        public decimal Devolver { get; set; }

        public int? Grupo { get; set; }

        public int SolicitudDeViatico { get; set; }

        public decimal? Solicitado { get; set; }

        public decimal? GastosSolicitados { get; set; }

    }

    public class SolicitudesDeViaticosCustom {

        public int Id { get; set; }
        public int Destino { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public string Motivo { get; set; }
        public string Descripcion_Destino { get; set; }
        public int MedioDeTransporte { get; set; }
        public int? AutoOficial { get; set; }
        public string Patente { get; set; }
        public string Seguro { get; set; }
        public string VigenciaSeguro { get; set; }
        public string TipoVehiculo { get; set; }
        public int? Comision { get; set; }

    }

}
