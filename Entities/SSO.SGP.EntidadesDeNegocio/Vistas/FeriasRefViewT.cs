using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class FeriasRefViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "FechaDesde")]
			public DateTime FechaDesde { get; set; }

			[Display(Name = "FechaHasta")]
			public DateTime FechaHasta { get; set; }

			[Display(Name = "Anio")]
			public int Anio { get; set; }

			[Display(Name = "DiaDesde")]
			public int DiaDesde { get; set; }

			[Display(Name = "MesDesde")]
			public int MesDesde { get; set; }

			[Display(Name = "DiaHasta")]
			public int DiaHasta { get; set; }

			[Display(Name = "MesHasta")]
			public int MesHasta { get; set; }

			[Display(Name = "Paso1")]
			public bool Paso1 { get; set; }

			[Display(Name = "Paso2")]
			public bool Paso2 { get; set; }
			#endregion


	}
}
