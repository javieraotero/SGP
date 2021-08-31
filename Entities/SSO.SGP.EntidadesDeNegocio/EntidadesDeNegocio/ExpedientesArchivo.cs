
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
	[MetadataTypeAttribute(typeof(ExpedientesArchivoMetaData))]
	[Table("ExpedientesArchivo")]
	public partial class ExpedientesArchivo
	{
		#region Constructor
		public ExpedientesArchivo()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Expediente")]
		public int Expediente { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioEnvio")]
		public int UsuarioEnvio { get; set; }

		[Required(ErrorMessage = "Debe ingresar Firmante")]
		public int Firmante { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaEnvio")]
		public DateTime FechaEnvio { get; set; }

		[StringLength(255, ErrorMessage ="Observaciones no puede superar los 255 caracteres")]
		public string Observaciones { get; set; }

		[Required(ErrorMessage = "Debe ingresar Anulado")]
		public bool Anulado { get; set; }

		public DateTime? FechaFinArchivo { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

		[ForeignKey("Expediente")]
		public virtual Expedientes Expedientes { get; set; }

		[ForeignKey("UsuarioEnvio")]
		public virtual Usuarios UsuarioEnvios { get; set; }

		[ForeignKey("Firmante")]
		public virtual Usuarios Firmantes { get; set; }
		#endregion

	}
}
