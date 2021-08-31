using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class TiposOrigenExpedienteRefMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "MostrarEnCaratula")]
			public bool MostrarEnCaratula { get; set; }

			[Display(Name = "MostrarEnOficinaJudicial")]
			public bool MostrarEnOficinaJudicial { get; set; }

			[Display(Name = "TipoActuacionInicio")]
			public int TipoActuacionInicio { get; set; }

			[Display(Name = "RequiereFiscal")]
			public bool RequiereFiscal { get; set; }

			[Display(Name = "RequiereJuez")]
			public bool RequiereJuez { get; set; }

			[Display(Name = "RequiereDefensor")]
			public bool RequiereDefensor { get; set; }
			#endregion


	}
}
