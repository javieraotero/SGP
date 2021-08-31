using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class FacturasMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "NumeroDeFactura")]
			public string NumeroDeFactura { get; set; }

			[Display(Name = "Identificador")]
			public int IdentificacionDeFactura { get; set; }

			[Display(Name = "Tipo")]
			public string Tipo { get; set; }

			[Display(Name = "Expediente")]
			public int? Expediente { get; set; }

			[Display(Name = "Proveedor")]
			public int? Proveedor { get; set; }

			[Display(Name = "Proveedor (texto)")]
			public string txtProveedor { get; set; }

			[Display(Name = "Fecha")]
			public DateTime Fecha { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "Importe")]
			public decimal Importe { get; set; }

			[Display(Name = "Organismo")]
			public int Organismo { get; set; }

			[Display(Name = "Agente")]
			public int? Agente { get; set; }

			[Display(Name = "Texto Agente")]
			public string TextoAgente { get; set; }

			[Display(Name = "Es Factura?")]
			public bool EsFactura { get; set; }

			[Display(Name = "Esta Asignada?")]
			public bool EstaAsignada { get; set; }

			[Display(Name = "Esta Pagada?")]
			public bool EstaPagada { get; set; }

			[Display(Name = "De Impuestos Municipales?")]
			public bool DeImpuestosMunicipales { get; set; }

			[Display(Name = "Comprobante #2")]
			public string Comprobante2 { get; set; }

			[Display(Name = "Comprobante #3")]
			public string Comprobante3 { get; set; }

			[Display(Name = "De Servicios?")]
			public bool DeServicios { get; set; }

			[Display(Name = "Fecha Desde")]
			public DateTime? FechaDesde { get; set; }

			[Display(Name = "Fecha Hasta")]
			public DateTime? FechaHasta { get; set; }

			[Display(Name = "Afectada?")]
			public bool? Afectada { get; set; }

			[Display(Name = "Compromiso?")]
			public bool? Compromiso { get; set; }

			[Display(Name = "Ordenado A Pagar?")]
			public bool? OrdenadoAPagar { get; set; }

			[Display(Name = "Grupo")]
			public int? Grupo { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime FechaAlta { get; set; }

			[Display(Name = "FechaModifica")]
			public DateTime FechaModifica { get; set; }

			[Display(Name = "FechaElimina")]
			public DateTime? FechaElimina { get; set; }

			[Display(Name = "UsuarioAlta")]
			public int UsuarioAlta { get; set; }

			[Display(Name = "UsuarioModifica")]
			public int UsuarioModifica { get; set; }

			[Display(Name = "UsuarioElimina")]
			public int? UsuarioElimina { get; set; }
			#endregion


	}
}
