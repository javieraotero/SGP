
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
	[MetadataTypeAttribute(typeof(FacturasMetaData))]
	[Table("Facturas")]
	public partial class Facturas
	{
		#region Constructor
		public Facturas()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar NumeroDeFactura")]
		[StringLength(15, ErrorMessage ="NumeroDeFactura no puede superar los 15 caracteres")]
		public string NumeroDeFactura { get; set; }

		[Required(ErrorMessage = "Debe ingresar IdentificacionDeFactura")]
		public int IdentificacionDeFactura { get; set; }

		[StringLength(2, ErrorMessage ="Tipo no puede superar los 2 caracteres")]
		public string Tipo { get; set; }

		public int? Expediente { get; set; }

		public int? Proveedor { get; set; }

		[StringLength(50, ErrorMessage ="txtProveedor no puede superar los 50 caracteres")]
		public string txtProveedor { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fecha")]
		public DateTime Fecha { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		[StringLength(255, ErrorMessage ="Descripcion no puede superar los 255 caracteres")]
		public string Descripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Importe")]
		public decimal Importe { get; set; }

		[Required(ErrorMessage = "Debe ingresar Organismo")]
		public int? Organismo { get; set; }

		public int? Agente { get; set; }

		[StringLength(50, ErrorMessage ="TextoAgente no puede superar los 50 caracteres")]
		public string TextoAgente { get; set; }

		[Required(ErrorMessage = "Debe ingresar EsFactura")]
		public bool EsFactura { get; set; }

		[Required(ErrorMessage = "Debe ingresar EstaAsignada")]
		public bool EstaAsignada { get; set; }

		[Required(ErrorMessage = "Debe ingresar EstaPagada")]
		public bool EstaPagada { get; set; }

		[Required(ErrorMessage = "Debe ingresar DeImpuestosMunicipales")]
		public bool DeImpuestosMunicipales { get; set; }

		[StringLength(15, ErrorMessage ="Comprobante2 no puede superar los 15 caracteres")]
		public string Comprobante2 { get; set; }

		[StringLength(15, ErrorMessage ="Comprobante3 no puede superar los 15 caracteres")]
		public string Comprobante3 { get; set; }

		[Required(ErrorMessage = "Debe ingresar DeServicios")]
		public bool DeServicios { get; set; }

		public DateTime? FechaDesde { get; set; }

		public DateTime? FechaHasta { get; set; }

		public bool Afectada { get; set; }

		public bool Compromiso { get; set; }

		public bool OrdenadoAPagar { get; set; }

		public int? Grupo { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaModifica")]
		public DateTime FechaModifica { get; set; }

		public DateTime? FechaElimina { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioAlta")]
		public int UsuarioAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioModifica")]
		public int UsuarioModifica { get; set; }

		public int? UsuarioElimina { get; set; }

        public int? Imputacion { get; set; }

		public virtual ICollection<FacturasImputadas> FacturasImputadas { get; set; }

		[ForeignKey("Expediente")]
		public virtual Expedientesadm Expedientes { get; set; }

		[ForeignKey("Proveedor")]
		public virtual Proveedores Proveedors { get; set; }

		[ForeignKey("Organismo")]
		public virtual OrganismosRef Organismos { get; set; }
		#endregion

	}
}
