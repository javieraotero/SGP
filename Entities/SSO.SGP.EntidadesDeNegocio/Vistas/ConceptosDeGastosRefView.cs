using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ConceptosDeGastosRefView
	{
			#region Propiedades

			[Display(Name = "Id", Order = 0)]
			public int Id { get; set; }

			[Display(Name = "Descripcion", Order = 35)]
			public string Descripcion { get; set; }

			[Display(Name = "Partida", Order = 45)]
			public string Partida { get; set; }
			#endregion


	}
}
