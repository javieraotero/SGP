using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ElementosSecuestradosDocumentoView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Elemento")]
			public int Elemento { get; set; }

			[Display(Name = "NombreOriginal")]
			public string NombreOriginal { get; set; }

			[Display(Name = "Extension")]
			public string Extension { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime FechaAlta { get; set; }

			[Display(Name = "Usuario")]
			public int Usuario { get; set; }

			[Display(Name = "Confirmado")]
			public bool Confirmado { get; set; }
			#endregion


	}
}
