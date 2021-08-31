using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class SucesosTitulosView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "Ambito")]
			public int Ambito { get; set; }

			[Display(Name = "TipoSuceso")]
			public int TipoSuceso { get; set; }

			[Display(Name = "MostrarEnEdicion")]
			public bool MostrarEnEdicion { get; set; }

			[Display(Name = "AplicaSuspencionPlazo")]
			public bool AplicaSuspencionPlazo { get; set; }

			[Display(Name = "Circunscripcion")]
			public int? Circunscripcion { get; set; }

			[Display(Name = "UsuarioAlta")]
			public int? UsuarioAlta { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime? FechaAlta { get; set; }

			[Display(Name = "UsuarioModifica")]
			public int? UsuarioModifica { get; set; }

			[Display(Name = "FechaModifica")]
			public DateTime? FechaModifica { get; set; }

			[Display(Name = "UsuarioElimina")]
			public int? UsuarioElimina { get; set; }

			[Display(Name = "FechaElimina")]
			public DateTime? FechaElimina { get; set; }
			#endregion


	}
}
