using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class MediadoresMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "UsuarioCarga")]
			public int UsuarioCarga { get; set; }

			[Display(Name = "UsuarioMediador")]
			public int UsuarioMediador { get; set; }

			[Display(Name = "EspecialidadEnFamilia")]
			public bool EspecialidadEnFamilia { get; set; }

			[Display(Name = "Activo")]
			public bool Activo { get; set; }

			[Display(Name = "Tipo")]
			public int Tipo { get; set; }

			[Display(Name = "FechaCarga")]
			public DateTime FechaCarga { get; set; }
			#endregion


	}
}
