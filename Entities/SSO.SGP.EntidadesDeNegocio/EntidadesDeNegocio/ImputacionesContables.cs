
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
	[MetadataTypeAttribute(typeof(ImputacionesContablesMetaData))]
	[Table("ImputacionesContables")]
	public partial class ImputacionesContables
	{
		#region Constructor
		public ImputacionesContables()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar ExpedienteAImputar")]
		public int ExpedienteAImputar { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fecha")]
		public DateTime Fecha { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioAlta")]
		public int UsuarioAlta { get; set; }

		public DateTime? FechaElimina { get; set; }

		[Required(ErrorMessage = "Debe ingresar Operacion")]
		public int Operacion { get; set; }

		public int? ExpedienteIndirecto { get; set; }

		public virtual ICollection<ImputacionesContablesDetalle> ImputacionesContablesDetalle { get; set; }

		[ForeignKey("ExpedienteAImputar")]
		public virtual Expedientesadm ExpedienteAImputars { get; set; }

		[ForeignKey("Operacion")]
		public virtual OperacionesContablesRef Operacions { get; set; }

		[ForeignKey("ExpedienteIndirecto")]
		public virtual Expedientesadm ExpedienteIndirectos { get; set; }
		#endregion

	}
}
