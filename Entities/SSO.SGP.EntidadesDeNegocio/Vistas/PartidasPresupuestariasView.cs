using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class PartidasPresupuestariasView
	{
			#region Propiedades

			[Display(Name = "Id", Order=0)]
			public int Id { get; set; }

			[Display(Name = "Número", Order=5)]
			public string NumeroDePartida { get; set; }

			[Display(Name = "Descripción", Order=20)]
			public string Descripcion { get; set; }

			[Display(Name = "Mnemo", Order=33)]
			public string Mnemo { get; set; }

			[Display(Name = "Unidad De Organización", Order=20)]
			public string UnidadDeOrganizacion { get; set; }

			[Display(Name = "Prioridad", Order=5)]
			public string Prioridad { get; set; }

			#endregion
	}
}
