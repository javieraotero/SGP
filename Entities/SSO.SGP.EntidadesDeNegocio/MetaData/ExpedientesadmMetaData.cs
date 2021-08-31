using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class ExpedientesadmMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Tipo")]
			public int Tipo { get; set; }

			[Display(Name = "Categoría")]
			public int Categoria { get; set; }

			[Display(Name = "Numero")]
			public int Numero { get; set; }

			[Display(Name = "Número de Trámite")]
			public int? NumeroDeTramite { get; set; }

			[Display(Name = "Número De Corresponde")]
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

			[Display(Name = "Carátula")]
			public string Caratula { get; set; }

			[Display(Name = "Organismo Iniciador")]
			public int? OrganismoIniciador { get; set; }

			[Display(Name = "Texto Iniciador")]
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

			[Display(Name = "Anio Contable")]
			public int? AnioContable { get; set; }

            [Display(Name = "Ámbito")]
            public int? Ambito { get; set; }

            [Display(Name = "Destino")]
            public int? Destino { get; set; }

			#endregion


	}
}
