using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class ActuacionesVocesMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Actuacion")]
			public int Actuacion { get; set; }

			[Display(Name = "Voz")]
			public int Voz { get; set; }

			[Display(Name = "Activo")]
			public bool Activo { get; set; }

			[Display(Name = "Confirmado")]
			public bool Confirmado { get; set; }
			#endregion


	}
}
