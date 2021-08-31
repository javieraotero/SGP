using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class EjecucionesPresupuestariasReestructurasMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Anio")]
			public int Anio { get; set; }

			[Display(Name = "PartidaPresupuestaria")]
			public int PartidaPresupuestaria { get; set; }

			[Display(Name = "Importe")]
			public decimal Importe { get; set; }

			[Display(Name = "Fecha")]
			public DateTime Fecha { get; set; }

			[Display(Name = "Observaciones")]
			public string Observaciones { get; set; }

			[Display(Name = "UsuarioAlta")]
			public int UsuarioAlta { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime FechaAlta { get; set; }

        [Display(Name = "Otorgado")]
        public decimal? ImporteOtorgado { get; set; }

        [Display(Name = "Fecha Otorgado")]
        public DateTime? FechaOtorgado { get; set; }

        [Display(Name = "Tipo")]
        public int? Tipo { get; set; }
        #endregion


    }
}
