using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class CesidaParametrosDeMovimientosView
	{
        #region Propiedades

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Display(Name = "TipoDeDato")]
        public int? TipoDeDato { get; set; }

        [Display(Name = "Obligatorio")]
        public bool Obligatorio { get; set; }

        [Display(Name = "Referencia")]
        public string Referencia { get; set; }

        [Display(Name = "Predeterminado")]
        public string Predeterminado { get; set; }
        #endregion


    }
}
