using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class AgentesDocenciaViewT
	{
        #region Propiedades

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Agente")]
        public int Agente { get; set; }

        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }

        [Display(Name = "Institucion")]
        public string Institucion { get; set; }

        [Display(Name = "CargaHoraria")]
        public int CargaHoraria { get; set; }

        [Display(Name = "HorasCatedra")]
        public bool HorasCatedra { get; set; }

        [Display(Name = "HorasSemanales")]
        public bool HorasSemanales { get; set; }

        [Display(Name = "Observaciones")]
        public string Observaciones { get; set; }

        [Display(Name = "Detalle")]
        public string Detalle { get; set; }
        #endregion


    }
}
