using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class GrupoFamiliarMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Agente")]
			public int Agente { get; set; }

			[Display(Name = "Apellido y Nombre")]
			public string ApellidosYNombre { get; set; }

			[Display(Name = "Fecha De Nacimiento")]
			public DateTime FechaDeNacimiento { get; set; }

			[Display(Name = "Documento")]
			public int Documento { get; set; }

			[Display(Name = "Parentesco")]
			public int TipoMiembro { get; set; }

			[Display(Name = "Activo")]
			public bool Activo { get; set; }

			[Display(Name = "FechaBaja")]
			public DateTime? FechaBaja { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime FechaAlta { get; set; }
			#endregion


	}
}
