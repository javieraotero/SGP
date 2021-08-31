using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class PreventivosMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Numero")]
			public string Numero { get; set; }

			[Display(Name = "Comisaria")]
			public int Comisaria { get; set; }

			[Display(Name = "FechaDenuncia")]
			public DateTime FechaDenuncia { get; set; }

			[Display(Name = "FechaHecho")]
			public DateTime FechaHecho { get; set; }

			[Display(Name = "Caratula")]
			public string Caratula { get; set; }

			[Display(Name = "AlertaActiva")]
			public bool AlertaActiva { get; set; }

			[Display(Name = "Estado")]
			public int Estado { get; set; }

			[Display(Name = "Reclamo")]
			public string Reclamo { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime FechaAlta { get; set; }

			[Display(Name = "UsuarioAlta")]
			public int UsuarioAlta { get; set; }

			[Display(Name = "FechaRecepcion")]
			public DateTime? FechaRecepcion { get; set; }

			[Display(Name = "UsuarioRecepcion")]
			public int? UsuarioRecepcion { get; set; }

			[Display(Name = "FechaAnulado")]
			public DateTime? FechaAnulado { get; set; }

			[Display(Name = "UsuarioAnulado")]
			public int? UsuarioAnulado { get; set; }

			[Display(Name = "Confirmado")]
			public bool Confirmado { get; set; }

			[Display(Name = "Bloqueado")]
			public bool? Bloqueado { get; set; }

			[Display(Name = "UsuarioBloquea")]
			public int? UsuarioBloquea { get; set; }

			[Display(Name = "FechaBloqueo")]
			public DateTime? FechaBloqueo { get; set; }

			[Display(Name = "AutoresIgnorados")]
			public bool AutoresIgnorados { get; set; }

			[Display(Name = "Ubicacion")]
			public string Ubicacion { get; set; }

			[Display(Name = "Firmante")]
			public int? Firmante { get; set; }

			[Display(Name = "NroPreventivoPolicia")]
			public string NroPreventivoPolicia { get; set; }

			[Display(Name = "NroSumarioPolicia")]
			public string NroSumarioPolicia { get; set; }

			[Display(Name = "Sector")]
			public int? Sector { get; set; }

			[Display(Name = "Sitio")]
			public int? Sitio { get; set; }

			[Display(Name = "JusticiaProvincial")]
			public int JusticiaProvincial { get; set; }

			[Display(Name = "Modalidad")]
			public int? Modalidad { get; set; }

			[Display(Name = "Calle")]
			public int? Calle { get; set; }

			[Display(Name = "Altura")]
			public string Altura { get; set; }
			#endregion


	}
}
