using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class AudienciasDemorasMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Audiencia")]
			public int Audiencia { get; set; }

			[Display(Name = "MotivoDemora")]
			public int MotivoDemora { get; set; }

			[Display(Name = "Observacion")]
			public string Observacion { get; set; }
			#endregion


	}
}
