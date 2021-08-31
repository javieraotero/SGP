using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ExpedientesadmViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Tipo")]
			public int Tipo { get; set; }

			[Display(Name = "Categoria")]
			public int Categoria { get; set; }

			[Display(Name = "Numero")]
			public string Numero { get; set; }

			[Display(Name = "NumeroDeTramite")]
			public int? NumeroDeTramite { get; set; }

			[Display(Name = "NumeroDeCorresponde")]
			public int? NumeroDeCorresponde { get; set; }

			[Display(Name = "FechaDeAlta")]
			public DateTime FechaDeAlta { get; set; }

			[Display(Name = "Fecha")]
			public DateTime Fecha { get; set; }

			[Display(Name = "UsuarioAlta")]
			public int? UsuarioAlta { get; set; }

			[Display(Name = "UsuarioBaja")]
			public int? UsuarioBaja { get; set; }

			[Display(Name = "FechaDeBaja")]
			public DateTime? FechaDeBaja { get; set; }

			[Display(Name = "Caratula")]
			public string Caratula { get; set; }

			[Display(Name = "OrganismoIniciador")]
			public int? OrganismoIniciador { get; set; }

			[Display(Name = "TextoIniciador")]
			public string TextoIniciador { get; set; }

			[Display(Name = "ExpedienteAcumulado")]
			public int? ExpedienteAcumulado { get; set; }

			[Display(Name = "FechaAcumulado")]
			public DateTime? FechaAcumulado { get; set; }

			[Display(Name = "UsuarioAcumulado")]
			public int? UsuarioAcumulado { get; set; }

			[Display(Name = "ExpedientePadre")]
			public int? ExpedientePadre { get; set; }

			[Display(Name = "UltimoCorresponde")]
			public int UltimoCorresponde { get; set; }

			[Display(Name = "Archivado")]
			public bool? Archivado { get; set; }

			[Display(Name = "FechaArchivado")]
			public DateTime? FechaArchivado { get; set; }

			[Display(Name = "UsuarioArchiva")]
			public int? UsuarioArchiva { get; set; }

			[Display(Name = "AnioContable")]
			public int? AnioContable { get; set; }
			#endregion


	}
}
