using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class DelitosRefView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "Articulos")]
			public string Articulos { get; set; }

			[Display(Name = "MesesPrescribe")]
			public int MesesPrescribe { get; set; }

			[Display(Name = "MapaDelito")]
			public bool MapaDelito { get; set; }

			[Display(Name = "Capitulo")]
			public int Capitulo { get; set; }

			[Display(Name = "Activo")]
			public bool Activo { get; set; }

			[Display(Name = "NivelPonderacion_CircI")]
			public int NivelPonderacion_CircI { get; set; }

			[Display(Name = "NivelPonderacion_CircII")]
			public int NivelPonderacion_CircII { get; set; }

			[Display(Name = "NivelPonderacion_CircIII")]
			public int NivelPonderacion_CircIII { get; set; }

			[Display(Name = "NivelPonderacion_CircIV")]
			public int NivelPonderacion_CircIV { get; set; }

			[Display(Name = "CondenaMinima")]
			public int? CondenaMinima { get; set; }

			[Display(Name = "TipoCondenaMinima")]
			public int? TipoCondenaMinima { get; set; }

			[Display(Name = "CondenaMaxima")]
			public int? CondenaMaxima { get; set; }

			[Display(Name = "TipoCondenaMaxima")]
			public int? TipoCondenaMaxima { get; set; }

			[Display(Name = "Ponderacion")]
			public double? Ponderacion { get; set; }

			[Display(Name = "Prescripcion")]
			public int? Prescripcion { get; set; }
			#endregion


	}
}
