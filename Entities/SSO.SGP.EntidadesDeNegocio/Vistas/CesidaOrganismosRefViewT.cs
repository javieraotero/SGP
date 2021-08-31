using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class CesidaOrganismosRefViewT
	{
        #region Propiedades

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "CodCaracter")]
        public int? CodCaracter { get; set; }

        [Display(Name = "Caracter")]
        public string Caracter { get; set; }

        [Display(Name = "CodJurisdiccion")]
        public string CodJurisdiccion { get; set; }

        [Display(Name = "Jurisdiccion")]
        public string Jurisdiccion { get; set; }

        [Display(Name = "CodUnidad")]
        public int? CodUnidad { get; set; }

        [Display(Name = "Unidad")]
        public string Unidad { get; set; }
        #endregion


    }
}
