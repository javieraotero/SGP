
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
	[MetadataTypeAttribute(typeof(AudienciasSolicitudPersonasRelMetaData))]
	[Table("AudienciasSolicitudPersonasRel")]
	public partial class AudienciasSolicitudPersonasRel
	{
		#region Constructor
		public AudienciasSolicitudPersonasRel()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Solicitud { get; set; }

		[Key]
		public int Parte { get; set; }

		[ForeignKey("Solicitud")]
		public virtual AudienciasSolicitud Solicituds { get; set; }

		[ForeignKey("Parte")]
		public virtual ExpedientesPersona Partes { get; set; }
		#endregion

	}
}
