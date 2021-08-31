using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class SucesosCausasViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime FechaAlta { get; set; }

			[Display(Name = "UsuarioAlta")]
			public int UsuarioAlta { get; set; }

			[Display(Name = "SubAmbito")]
			public int SubAmbito { get; set; }

			[Display(Name = "Titulo")]
			public int Titulo { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "TipoSuceso")]
			public int TipoSuceso { get; set; }

			[Display(Name = "FechaMostrar")]
			public DateTime FechaMostrar { get; set; }

			[Display(Name = "TareaRealizada")]
			public bool TareaRealizada { get; set; }

			[Display(Name = "FechaRealizada")]
			public DateTime? FechaRealizada { get; set; }

			[Display(Name = "UsuarioRealizada")]
			public int? UsuarioRealizada { get; set; }

			[Display(Name = "Causa")]
			public int? Causa { get; set; }

			[Display(Name = "Actuacion")]
			public int? Actuacion { get; set; }

			[Display(Name = "Activa")]
			public bool Activa { get; set; }

			[Display(Name = "FechaEliminacion")]
			public DateTime? FechaEliminacion { get; set; }

			[Display(Name = "UsuarioEliminacion")]
			public int? UsuarioEliminacion { get; set; }

			[Display(Name = "ResponsableEvento")]
			public int? ResponsableEvento { get; set; }

			[Display(Name = "OficinaEvento")]
			public int? OficinaEvento { get; set; }

			[Display(Name = "ModificadoPorSuspencion")]
			public bool ModificadoPorSuspencion { get; set; }
			#endregion


	}
}
