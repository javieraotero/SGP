using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class PeritosSancionesMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Perito")]
			public int Perito { get; set; }

			[Display(Name = "SuspendidoDesde")]
			public DateTime SuspendidoDesde { get; set; }

			[Display(Name = "SuspendidoHasta")]
			public DateTime SuspendidoHasta { get; set; }

			[Display(Name = "Sanciones")]
			public string Sanciones { get; set; }
			#endregion


	}
}
