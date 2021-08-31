using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class SolicitudesDeViaticosRendicionesView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "SolicitudDeViatico")]
			public int SolicitudDeViatico { get; set; }

			[Display(Name = "FechaDeInicio")]
			public DateTime FechaDeInicio { get; set; }

			[Display(Name = "FechaDeFin")]
			public DateTime FechaDeFin { get; set; }

			[Display(Name = "TotalBienesDeConsumo")]
			public decimal TotalBienesDeConsumo { get; set; }

			[Display(Name = "TotalServiciosNoPersonales")]
			public decimal TotalServiciosNoPersonales { get; set; }

			[Display(Name = "TotalOtros")]
			public decimal TotalOtros { get; set; }

			[Display(Name = "FechaDeAlta")]
			public DateTime FechaDeAlta { get; set; }

			[Display(Name = "UsuarioAlta")]
			public int UsuarioAlta { get; set; }
			#endregion


	}
}
