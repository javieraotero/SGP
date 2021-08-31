using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class ModelosEscritoMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Oficina")]
			public int? Oficina { get; set; }

			[Display(Name = "Titulo")]
			public string Titulo { get; set; }

			[Display(Name = "Contenido")]
			public string Contenido { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime FechaAlta { get; set; }

			[Display(Name = "Usuario")]
			public int Usuario { get; set; }

			[Display(Name = "Tipo")]
			public int Tipo { get; set; }

			[Display(Name = "TipoActuacion")]
			public int? TipoActuacion { get; set; }

			[Display(Name = "UsuarioModifica")]
			public int? UsuarioModifica { get; set; }

			[Display(Name = "FechaModifica")]
			public DateTime? FechaModifica { get; set; }
			#endregion


	}
}
