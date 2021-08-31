
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
	[MetadataTypeAttribute(typeof(EstadosExpedienteRefMetaData))]
	[Table("EstadosExpedienteRef")]
	public partial class EstadosExpedienteRef
	{
		#region Constructor
		public EstadosExpedienteRef()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		[StringLength(50, ErrorMessage ="Descripcion no puede superar los 50 caracteres")]
		public string Descripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar GrupoEstado")]
		public int GrupoEstado { get; set; }

		[Required(ErrorMessage = "Debe ingresar Finaliza")]
		public bool Finaliza { get; set; }

		public virtual ICollection<Expedientes> Expedientes { get; set; }

		public virtual ICollection<ExpedientesEstado> ExpedientesEstado { get; set; }

		public virtual ICollection<TiposActuacionRef> TiposActuacionRef { get; set; }

		[ForeignKey("GrupoEstado")]
		public virtual GruposEstadoExpedienteRef GrupoEstados { get; set; }
		#endregion

	}
}
