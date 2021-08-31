
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SSO.SGP.MetaData;


namespace SSO.SGP.EntidadesDeNegocio
{
	/// <summary>
	/// Entidad Generada por el Generador de codigo.
	/// </summary>
	[MetadataTypeAttribute(typeof(BienesMetaData))]
	[Table("Bienes")]
	public partial class Bienes
	{
		#region Constructor
		public Bienes()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar IdTipoDeBien")]
		public int IdTipoDeBien { get; set; }

		[Required(ErrorMessage = "Debe ingresar Organizacion")]
		public int Organizacion { get; set; }

		public int? NumeroDeInventario { get; set; }

		[Required(ErrorMessage = "Debe ingresar NumeroDeInventarioDeJusticia")]
		public int NumeroDeInventarioDeJusticia { get; set; }

		[Required(ErrorMessage = "Debe ingresar Nombre")]
		public string Nombre { get; set; }

		[Required(ErrorMessage = "Debe ingresar TipoDeIngreso")]
		public int TipoDeIngreso { get; set; }

		public decimal? Costo { get; set; }

		public DateTime? FechaDeComprobante { get; set; }

		public int? Expediente { get; set; }

		public int? ExpedienteDescargo { get; set; }

		public int? Marca { get; set; }

		public int? Modelo { get; set; }

		public string NumeroDeSerie { get; set; }

		public string Dimension { get; set; }

		public int? PlanillaDeCargo { get; set; }

		public int? PlanillaDeDescargo { get; set; }

		public DateTime? FechaDeIngreso { get; set; }

		public DateTime? FechaDeEgreso { get; set; }

		public int? ResponsablePrimario { get; set; }

		public int? ResponsableSecundario { get; set; }

		public int? ResponsableDeUso { get; set; }

		public DateTime? FechaDeCarga { get; set; }

		public string TextoDeMarca { get; set; }

		public string TextoDeModelo { get; set; }

		public bool EsInventariable { get; set; }

		[Required(ErrorMessage = "Debe ingresar Anulado")]
		public bool Anulado { get; set; }

		public int Factura { get; set; }

		public bool EsStock { get; set; }

		public int? Estado { get; set; }

		public bool Control { get; set; }

		public string ExpedienteProvincia { get; set; }
		#endregion

	}
}
