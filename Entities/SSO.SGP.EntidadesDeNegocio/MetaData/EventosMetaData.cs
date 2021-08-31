using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class EventosMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Fecha")]
			public DateTime Fecha { get; set; }

			[Display(Name = "Oficina")]
			public int Oficina { get; set; }

			[Display(Name = "Usuario")]
			public int Usuario { get; set; }

			[Display(Name = "Titulo")]
			public string Titulo { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "AlcanceEvento")]
			public int AlcanceEvento { get; set; }

			[Display(Name = "Expediente")]
			public int? Expediente { get; set; }

			[Display(Name = "Audiencia")]
			public int? Audiencia { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime? FechaAlta { get; set; }

			[Display(Name = "Activo")]
			public bool Activo { get; set; }
			#endregion


	}
}
