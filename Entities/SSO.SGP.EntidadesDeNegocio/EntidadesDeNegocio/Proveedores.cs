
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
	[MetadataTypeAttribute(typeof(ProveedoresMetaData))]
	[Table("Proveedores")]
	public partial class Proveedores
	{
		#region Constructor
		public Proveedores()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Nombre")]
		[StringLength(75, ErrorMessage ="Nombre no puede superar los 75 caracteres")]
		public string Nombre { get; set; }

		public int? NumeroAcreedor { get; set; }

		[StringLength(45, ErrorMessage ="RazonSocial no puede superar los 45 caracteres")]
		public string RazonSocial { get; set; }

		[StringLength(30, ErrorMessage ="NombreFantasia no puede superar los 30 caracteres")]
		public string NombreFantasia { get; set; }

		[StringLength(29, ErrorMessage ="DomicilioReal no puede superar los 29 caracteres")]
		public string DomicilioReal { get; set; }

		public int? CodigoPostal { get; set; }

		[StringLength(12, ErrorMessage ="CUIT no puede superar los 12 caracteres")]
		public string CUIT { get; set; }

		[StringLength(10, ErrorMessage ="IngresosBrutos no puede superar los 10 caracteres")]
		public string IngresosBrutos { get; set; }

		public bool? ExentoGanancias { get; set; }

		public bool? ExentoIngresosBrutos { get; set; }

		public bool? InscriptoEnGanancias { get; set; }

		[StringLength(1, ErrorMessage ="Estado no puede superar los 1 caracteres")]
		public string Estado { get; set; }

		public DateTime? FechaInscripcion { get; set; }

		public DateTime? FechaReInscripcion { get; set; }

		public DateTime? FechaFinExentoSellado { get; set; }

		public DateTime? FechaFinSuspension { get; set; }

		public DateTime? FechaFinExentoGanancias { get; set; }

		public DateTime? FechaFinExentoIngresosBrutos { get; set; }

		public DateTime? FechaBaja { get; set; }

		public bool? ExentoSellos { get; set; }

		public bool? AjustePorInflacion { get; set; }

		public int? FormaDePago { get; set; }

		[StringLength(30, ErrorMessage ="NumeroDeCuenta no puede superar los 30 caracteres")]
		public string NumeroDeCuenta { get; set; }

		[StringLength(50, ErrorMessage ="CBU no puede superar los 50 caracteres")]
		public string CBU { get; set; }

		public int? TipoDeCuenta { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaModifica")]
		public DateTime FechaModifica { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioAlta")]
		public int UsuarioAlta { get; set; }

		public int? UsuarioBaja { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioModifica")]
		public int UsuarioModifica { get; set; }

		[ForeignKey("FormaDePago")]
		public virtual FormasDePagoRef FormaDePagos { get; set; }

		[ForeignKey("TipoDeCuenta")]
		public virtual TiposCuentasBancariasRef TipoDeCuentas { get; set; }
		#endregion

	}
}
