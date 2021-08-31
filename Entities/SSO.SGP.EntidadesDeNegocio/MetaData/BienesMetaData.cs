using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class BienesMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "IdTipoDeBien")]
			public int IdTipoDeBien { get; set; }

			[Display(Name = "Organizacion")]
			public int Organizacion { get; set; }

			[Display(Name = "NumeroDeInventario")]
			public int? NumeroDeInventario { get; set; }

			[Display(Name = "NumeroDeInventarioDeJusticia")]
			public int NumeroDeInventarioDeJusticia { get; set; }

			[Display(Name = "Nombre")]
			public string Nombre { get; set; }

			[Display(Name = "TipoDeIngreso")]
			public int TipoDeIngreso { get; set; }

			[Display(Name = "Costo")]
			public decimal? Costo { get; set; }

			[Display(Name = "FechaDeComprobante")]
			public DateTime? FechaDeComprobante { get; set; }

			[Display(Name = "Expediente")]
			public int? Expediente { get; set; }

			[Display(Name = "ExpedienteDescargo")]
			public int? ExpedienteDescargo { get; set; }

			[Display(Name = "Marca")]
			public int? Marca { get; set; }

			[Display(Name = "Modelo")]
			public int? Modelo { get; set; }

			[Display(Name = "NumeroDeSerie")]
			public string NumeroDeSerie { get; set; }

			[Display(Name = "Dimension")]
			public string Dimension { get; set; }

			[Display(Name = "PlanillaDeCargo")]
			public int? PlanillaDeCargo { get; set; }

			[Display(Name = "PlanillaDeDescargo")]
			public int? PlanillaDeDescargo { get; set; }

			[Display(Name = "FechaDeIngreso")]
			public DateTime? FechaDeIngreso { get; set; }

			[Display(Name = "FechaDeEgreso")]
			public DateTime? FechaDeEgreso { get; set; }

			[Display(Name = "ResponsablePrimario")]
			public int? ResponsablePrimario { get; set; }

			[Display(Name = "ResponsableSecundario")]
			public int? ResponsableSecundario { get; set; }

			[Display(Name = "ResponsableDeUso")]
			public int? ResponsableDeUso { get; set; }

			[Display(Name = "FechaDeCarga")]
			public DateTime? FechaDeCarga { get; set; }

			[Display(Name = "TextoDeMarca")]
			public string TextoDeMarca { get; set; }

			[Display(Name = "TextoDeModelo")]
			public string TextoDeModelo { get; set; }

			[Display(Name = "EsInventariable")]
			public bool EsInventariable { get; set; }

			[Display(Name = "Anulado")]
			public bool Anulado { get; set; }

			[Display(Name = "Factura")]
			public int? Factura { get; set; }

			[Display(Name = "EsStock")]
			public bool EsStock { get; set; }

			[Display(Name = "Estado")]
			public int? Estado { get; set; }

			[Display(Name = "Control")]
			public  bool Control { get; set; }

			[Display(Name = "ExpedienteProvincia")]
			public string ExpedienteProvincia { get; set; }
			#endregion


	}
}
