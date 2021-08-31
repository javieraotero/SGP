using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class AudienciasAnterioresMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "FechaDesde")]
			public DateTime FechaDesde { get; set; }

			[Display(Name = "FechaHasta")]
			public DateTime FechaHasta { get; set; }

			[Display(Name = "DiaDesde")]
			public int DiaDesde { get; set; }

			[Display(Name = "MesDesde")]
			public int MesDesde { get; set; }

			[Display(Name = "AnioDesde")]
			public int AnioDesde { get; set; }

			[Display(Name = "DiaHasta")]
			public int DiaHasta { get; set; }

			[Display(Name = "MesHasta")]
			public int MesHasta { get; set; }

			[Display(Name = "AnioHasta")]
			public int AnioHasta { get; set; }

			[Display(Name = "Agente")]
			public int Agente { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "Activa")]
			public bool Activa { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime? FechaAlta { get; set; }

			[Display(Name = "FechaModificacion")]
			public DateTime? FechaModificacion { get; set; }

			[Display(Name = "FechaEliminacion")]
			public DateTime? FechaEliminacion { get; set; }
			#endregion


	}
}
