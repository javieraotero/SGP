using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ReservaSalasAudienciaView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Sala")]
			public int Sala { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "FechaDesde")]
			public DateTime FechaDesde { get; set; }

			[Display(Name = "FechaHasta")]
			public DateTime FechaHasta { get; set; }

			[Display(Name = "Activa")]
			public bool Activa { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime FechaAlta { get; set; }

			[Display(Name = "UsuarioAlta")]
			public int UsuarioAlta { get; set; }

			[Display(Name = "FechaModificacion")]
			public DateTime? FechaModificacion { get; set; }

			[Display(Name = "UsuarioModificacion")]
			public int? UsuarioModificacion { get; set; }
			#endregion


	}
}
