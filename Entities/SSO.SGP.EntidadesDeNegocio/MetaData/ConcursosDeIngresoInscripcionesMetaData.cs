using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class ConcursosDeIngresoInscripcionesMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "ConcursoDeIngreso")]
			public int ConcursoDeIngreso { get; set; }

			[Display(Name = "FechaPreinscripcion")]
			public DateTime? FechaPreinscripcion { get; set; }

			[Display(Name = "Apellido")]
			public string Apellido { get; set; }

			[Display(Name = "Nombres")]
			public string Nombres { get; set; }

			[Display(Name = "DNI")]
			public string DNI { get; set; }

			[Display(Name = "FechaDeNacimiento")]
			public DateTime? FechaDeNacimiento { get; set; }

			[Display(Name = "Domicilio")]
			public string Domicilio { get; set; }

			[Display(Name = "Ciudad")]
			public string Ciudad { get; set; }

			[Display(Name = "Provincia")]
			public string Provincia { get; set; }

			[Display(Name = "Telefono")]
			public string Telefono { get; set; }

			[Display(Name = "Email")]
			public string Email { get; set; }

			[Display(Name = "TituloSecundario")]
			public string TituloSecundario { get; set; }

			[Display(Name = "ExpedidoPor")]
			public string ExpedidoPor { get; set; }

			[Display(Name = "FechaExpedido")]
			public DateTime? FechaExpedido { get; set; }

			[Display(Name = "TituloUniversitario")]
			public string TituloUniversitario { get; set; }

			[Display(Name = "TituloUniversitarioFecha")]
			public DateTime? TituloUniversitarioFecha { get; set; }

			[Display(Name = "TituloUniversitarioExpedido")]
			public string TituloUniversitarioExpedido { get; set; }

			[Display(Name = "AntecedentesAcademicos")]
			public string AntecedentesAcademicos { get; set; }

			[Display(Name = "AntecedentesLaborales")]
			public string AntecedentesLaborales { get; set; }

			[Display(Name = "FechaRecepcion")]
			public DateTime? FechaRecepcion { get; set; }

			[Display(Name = "UsuarioRecepcion")]
			public int? UsuarioRecepcion { get; set; }

			[Display(Name = "Token")]
			public string Token { get; set; }
			#endregion


	}
}
