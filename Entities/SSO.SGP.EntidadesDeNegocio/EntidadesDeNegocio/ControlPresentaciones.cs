
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
	[MetadataTypeAttribute(typeof(ControlPresentacionesMetaData))]
	[Table("ControlPresentaciones")]
	public partial class ControlPresentaciones
	{
		#region Constructor
		public ControlPresentaciones()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar ExpedientePersona")]
		public int ExpedientePersona { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaPresentacion")]
		public DateTime FechaPresentacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Firma")]
		public bool Firma { get; set; }

		[StringLength(100, ErrorMessage ="Observaciones no puede superar los 100 caracteres")]
		public string Observaciones { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioAlta")]
		public int UsuarioAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaModificacion")]
		public DateTime FechaModificacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioModifica")]
		public int UsuarioModifica { get; set; }

		[ForeignKey("ExpedientePersona")]
		public virtual ExpedientesPersona ExpedientePersonas { get; set; }
		#endregion

	}
}
