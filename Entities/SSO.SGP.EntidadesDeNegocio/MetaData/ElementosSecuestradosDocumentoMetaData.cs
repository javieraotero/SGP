using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class ElementosSecuestradosDocumentoMetaData
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
