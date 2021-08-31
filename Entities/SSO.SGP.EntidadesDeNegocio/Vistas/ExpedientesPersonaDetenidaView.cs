using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ExpedientesPersonaDetenidaView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Expediente")]
			public int Expediente { get; set; }

			[Display(Name = "Persona")]
			public int Persona { get; set; }

			[Display(Name = "LugarDetencion")]
			public int? LugarDetencion { get; set; }

			[Display(Name = "FechaDesde")]
			public DateTime FechaDesde { get; set; }

			[Display(Name = "FechaHasta")]
			public DateTime? FechaHasta { get; set; }

			[Display(Name = "Observaciones")]
			public string Observaciones { get; set; }

			[Display(Name = "Anulada")]
			public bool Anulada { get; set; }

			[Display(Name = "MedidaSustitutiva")]
			public bool MedidaSustitutiva { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime FechaAlta { get; set; }

			[Display(Name = "UsuarioAlta")]
			public int UsuarioAlta { get; set; }

			[Display(Name = "FechaModificacion")]
			public DateTime? FechaModificacion { get; set; }

			[Display(Name = "UsuarioModifica")]
			public int? UsuarioModifica { get; set; }

			[Display(Name = "FechaAnula")]
			public DateTime? FechaAnula { get; set; }

			[Display(Name = "UsuarioAnula")]
			public int? UsuarioAnula { get; set; }

			[Display(Name = "DenidoPorOficinaJudicial")]
			public int? DenidoPorOficinaJudicial { get; set; }

			[Display(Name = "Anulada72HS")]
			public bool Anulada72HS { get; set; }
			#endregion


	}
}
