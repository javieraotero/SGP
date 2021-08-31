using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class BienesViewT
	{
        #region Propiedades

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Tipo")]
        public string TipoDeBien { get; set; }

        [Display(Name = "Organizacion")]
        public string Organizacion { get; set; }

        [Display(Name = "NumeroDeInventario")]
        public int? NumeroDeInventario { get; set; }

        [Display(Name = "NumeroDeInventarioDeJusticia")]
        public string NumeroDeInventarioDeJusticia { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "PlanillaDeCargo")]
        public int? PlanillaDeCargo { get; set; }

        [Display(Name = "PlanillaDeDescargo")]
        public int? PlanillaDeDescargo { get; set; }
        #endregion


    }
}
