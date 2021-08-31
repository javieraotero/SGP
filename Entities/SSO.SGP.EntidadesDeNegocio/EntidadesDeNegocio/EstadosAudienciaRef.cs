
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
	[MetadataTypeAttribute(typeof(EstadosAudienciaRefMetaData))]
	[Table("EstadosAudienciaRef")]
	public partial class EstadosAudienciaRef
	{
		#region Constructor
		public EstadosAudienciaRef()
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

		public int? GrupoEstadoAudiencia { get; set; }

		public virtual ICollection<Audiencias> Audiencias { get; set; }

		public virtual ICollection<AudienciasCivil> AudienciasCivil { get; set; }

		public virtual ICollection<AudienciasEstados> AudienciasEstados { get; set; }

		public virtual ICollection<AudienciasEstadosCivil> AudienciasEstadosCivil { get; set; }

		[ForeignKey("GrupoEstadoAudiencia")]
		public virtual GruposEstadoAudienciaRef GrupoEstadoAudiencias { get; set; }
		#endregion

	}
}
