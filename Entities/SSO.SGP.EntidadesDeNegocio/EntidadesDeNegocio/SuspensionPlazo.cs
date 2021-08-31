
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
	[MetadataTypeAttribute(typeof(SuspensionPlazoMetaData))]
	[Table("SuspensionPlazo")]
	public partial class SuspensionPlazo
	{
		#region Constructor
		public SuspensionPlazo()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaDesde")]
		public DateTime FechaDesde { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaHasta")]
		public DateTime FechaHasta { get; set; }

		[Required(ErrorMessage = "Debe ingresar Observaciones")]
		[StringLength(255, ErrorMessage ="Observaciones no puede superar los 255 caracteres")]
		public string Observaciones { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioAlta")]
		public int UsuarioAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

		public int? UsuarioModifica { get; set; }

		public DateTime? FechaModificacion { get; set; }
		#endregion

	}
}
