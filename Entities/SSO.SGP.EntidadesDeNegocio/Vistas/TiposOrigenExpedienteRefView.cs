using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class TiposOrigenExpedienteRefView
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
