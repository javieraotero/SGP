using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class FeriasRefView
	{
			#region Propiedades

			[Display(Name = "Id", Order = 0)]
			public int Id { get; set; }

			[Display(Name = "Descripcion", Order=40)]
			public string Descripcion { get; set; }

			[Display(Name = "FechaDesde", Order= 10)]
			public DateTime FechaDesde { get; set; }

			[Display(Name = "FechaHasta", Order = 10)]
			public DateTime FechaHasta { get; set; }

			[Display(Name = "Anio", Order=5)]
			public int Anio { get; set; }

			[Display(Name = "Paso1", Order=5)]
			public bool Paso1 { get; set; }

			[Display(Name = "Paso2", Order= 5)]
			public bool Paso2 { get; set; }
			#endregion


	}
}
