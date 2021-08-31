using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class PartidasPresupuestariasMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Numero De Partida")]
			public string NumeroDePartida { get; set; }

			[Display(Name = "Descripción")]
			public string Descripcion { get; set; }

			[Display(Name = "Mnemo")]
			public string Mnemo { get; set; }

			[Display(Name = "Unidad De Organización")]
			public int UnidadDeOrganizacion { get; set; }

			[Display(Name = "Prioridad")]
			public bool Prioridad { get; set; }
			#endregion


	}
}
