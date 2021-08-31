using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class MateriasView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "Mnemo")]
			public string Mnemo { get; set; }

			[Display(Name = "Tipo")]
			public int? Tipo { get; set; }

			[Display(Name = "EjerceAtraccion")]
			public bool EjerceAtraccion { get; set; }

			[Display(Name = "Civil")]
			public int? Civil { get; set; }

			[Display(Name = "Laboral")]
			public int? Laboral { get; set; }

			[Display(Name = "Publica")]
			public bool Publica { get; set; }

			[Display(Name = "Familia")]
			public int? Familia { get; set; }

			[Display(Name = "Exorto")]
			public bool Exorto { get; set; }

			[Display(Name = "Vigente")]
			public bool Vigente { get; set; }

			[Display(Name = "Mediacion")]
			public int Mediacion { get; set; }

			[Display(Name = "Concursos_Quiebras")]
			public int? Concursos_Quiebras { get; set; }

			[Display(Name = "Activo")]
			public bool Activo { get; set; }

			[Display(Name = "CategoriaUnica")]
			public int? CategoriaUnica { get; set; }
			#endregion


	}
}
