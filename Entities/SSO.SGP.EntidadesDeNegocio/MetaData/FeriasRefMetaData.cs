using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class FeriasRefMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Descripción")]
			public string Descripcion { get; set; }

			[Display(Name = "Fecha Desde")]
			public DateTime FechaDesde { get; set; }

			[Display(Name = "Fecha Hasta")]
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
