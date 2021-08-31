using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class ExpedientesAnotacionesMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Expediente")]
			public int Expediente { get; set; }

			[Display(Name = "Titulo")]
			public string Titulo { get; set; }

			[Display(Name = "Fundamento")]
			public string Fundamento { get; set; }

			[Display(Name = "OficinaOrigen")]
			public int OficinaOrigen { get; set; }

			[Display(Name = "SubAmbitoOrigen")]
			public int SubAmbitoOrigen { get; set; }

			[Display(Name = "Activo")]
			public bool Activo { get; set; }

			[Display(Name = "UsuarioAlta")]
			public int UsuarioAlta { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime FechaAlta { get; set; }

			[Display(Name = "UsuarioModifica")]
			public int UsuarioModifica { get; set; }

			[Display(Name = "FechaModifica")]
			public DateTime FechaModifica { get; set; }

			[Display(Name = "FechaElimina")]
			public DateTime? FechaElimina { get; set; }

			[Display(Name = "UsuarioElimina")]
			public int? UsuarioElimina { get; set; }

			[Display(Name = "FundamentoMax")]
			public string FundamentoMax { get; set; }
			#endregion


	}
}
