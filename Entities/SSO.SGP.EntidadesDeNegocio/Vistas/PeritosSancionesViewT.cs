using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class PeritosSancionesViewT
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
