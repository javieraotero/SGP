using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class ProtocolosMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "RequiereVoces")]
			public bool RequiereVoces { get; set; }

			[Display(Name = "Ambito")]
			public int Ambito { get; set; }

			[Display(Name = "Activo")]
			public bool Activo { get; set; }
			#endregion


	}
}
