using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ProveedoresViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Nombre")]
			public string Nombre { get; set; }

			[Display(Name = "NumeroAcreedor")]
			public int? NumeroAcreedor { get; set; }

			[Display(Name = "RazonSocial")]
			public string RazonSocial { get; set; }

			[Display(Name = "NombreFantasia")]
			public string NombreFantasia { get; set; }

			[Display(Name = "DomicilioReal")]
			public string DomicilioReal { get; set; }

			[Display(Name = "CodigoPostal")]
			public int? CodigoPostal { get; set; }

			[Display(Name = "CUIT")]
			public string CUIT { get; set; }

			[Display(Name = "IngresosBrutos")]
			public string IngresosBrutos { get; set; }

			[Display(Name = "ExentoGanancias")]
			public bool? ExentoGanancias { get; set; }

			[Display(Name = "ExentoIngresosBrutos")]
			public bool? ExentoIngresosBrutos { get; set; }

			[Display(Name = "InscriptoEnGanancias")]
			public bool? InscriptoEnGanancias { get; set; }

			[Display(Name = "Estado")]
			public string Estado { get; set; }

			[Display(Name = "FechaInscripcion")]
			public DateTime? FechaInscripcion { get; set; }

			[Display(Name = "FechaReInscripcion")]
			public DateTime? FechaReInscripcion { get; set; }

			[Display(Name = "FechaFinExentoSellado")]
			public DateTime? FechaFinExentoSellado { get; set; }

			[Display(Name = "FechaFinSuspension")]
			public DateTime? FechaFinSuspension { get; set; }

			[Display(Name = "FechaFinExentoGanancias")]
			public DateTime? FechaFinExentoGanancias { get; set; }

			[Display(Name = "FechaFinExentoIngresosBrutos")]
			public DateTime? FechaFinExentoIngresosBrutos { get; set; }

			[Display(Name = "FechaBaja")]
			public DateTime? FechaBaja { get; set; }

			[Display(Name = "ExentoSellos")]
			public bool? ExentoSellos { get; set; }

			[Display(Name = "AjustePorInflacion")]
			public bool? AjustePorInflacion { get; set; }

			[Display(Name = "FormaDePago")]
			public int? FormaDePago { get; set; }

			[Display(Name = "NumeroDeCuenta")]
			public string NumeroDeCuenta { get; set; }

			[Display(Name = "CBU")]
			public string CBU { get; set; }

			[Display(Name = "TipoDeCuenta")]
			public int? TipoDeCuenta { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime FechaAlta { get; set; }

			[Display(Name = "FechaModifica")]
			public DateTime FechaModifica { get; set; }

			[Display(Name = "UsuarioAlta")]
			public int UsuarioAlta { get; set; }

			[Display(Name = "UsuarioBaja")]
			public int? UsuarioBaja { get; set; }

			[Display(Name = "UsuarioModifica")]
			public int UsuarioModifica { get; set; }
			#endregion


	}
}
