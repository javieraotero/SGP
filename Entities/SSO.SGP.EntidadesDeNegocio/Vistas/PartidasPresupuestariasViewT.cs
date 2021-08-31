using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class PartidasPresupuestariasViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "NumeroDePartida")]
			public string NumeroDePartida { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "Mnemo")]
			public string Mnemo { get; set; }

			[Display(Name = "UnidadDeOrganizacion")]
			public int UnidadDeOrganizacion { get; set; }

			[Display(Name = "Prioridad")]
			public bool Prioridad { get; set; }
			#endregion


	}
}
