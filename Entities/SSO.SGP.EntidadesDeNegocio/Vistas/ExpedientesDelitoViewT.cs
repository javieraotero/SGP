using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ExpedientesDelitoViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Expediente")]
			public int Expediente { get; set; }

			[Display(Name = "Delito")]
			public int Delito { get; set; }

			[Display(Name = "FechaDesde")]
			public DateTime? FechaDesde { get; set; }

			[Display(Name = "FechaHasta")]
			public DateTime? FechaHasta { get; set; }

			[Display(Name = "HoraDesde")]
			public string HoraDesde { get; set; }

			[Display(Name = "HoraHasta")]
			public string HoraHasta { get; set; }

			[Display(Name = "Barrio")]
			public int? Barrio { get; set; }

			[Display(Name = "Calle")]
			public int? Calle { get; set; }

			[Display(Name = "Calle1")]
			public int? Calle1 { get; set; }

			[Display(Name = "Calle2")]
			public int? Calle2 { get; set; }

			[Display(Name = "Nro")]
			public int? Nro { get; set; }

			[Display(Name = "DescripcionUbicacion")]
			public string DescripcionUbicacion { get; set; }

			[Display(Name = "Observaciones")]
			public string Observaciones { get; set; }

			[Display(Name = "CantidadHechos")]
			public int CantidadHechos { get; set; }

			[Display(Name = "Tentativa")]
			public bool Tentativa { get; set; }

			[Display(Name = "UbicacionExacta")]
			public bool UbicacionExacta { get; set; }

			[Display(Name = "Flagrancia")]
			public bool Flagrancia { get; set; }

			[Display(Name = "Localidad")]
			public int? Localidad { get; set; }

			[Display(Name = "Activo")]
			public bool? Activo { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime? FechaAlta { get; set; }

			[Display(Name = "UsuarioAlta")]
			public int? UsuarioAlta { get; set; }

			[Display(Name = "FechaModificacion")]
			public DateTime? FechaModificacion { get; set; }

			[Display(Name = "UsuarioModificacion")]
			public int? UsuarioModificacion { get; set; }

			[Display(Name = "FechaBaja")]
			public DateTime? FechaBaja { get; set; }

			[Display(Name = "UsuarioBaja")]
			public int? UsuarioBaja { get; set; }
			#endregion


	}
}
