using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class PresupuestacionCapitalesMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Presupuestacion")]
			public int Presupuestacion { get; set; }

			[Display(Name = "Fecha")]
			public DateTime Fecha { get; set; }

			[Display(Name = "Monto")]
			public decimal Monto { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }
			#endregion


	}
}
