
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
	[MetadataTypeAttribute(typeof(ExpedientesPaseadmMetaData))]
	[Table("ExpedientesPaseadm")]
	public partial class ExpedientesPaseadm
	{
		#region Constructor
		public ExpedientesPaseadm()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Expediente")]
		public int Expediente { get; set; }

		public int? Actuacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fecha")]
		public DateTime Fecha { get; set; }

		[Required(ErrorMessage = "Debe ingresar OrganismoReceptor")]
		public int OrganismoReceptor { get; set; }

		[ForeignKey("Expediente")]
		public virtual Expedientesadm Expedientes { get; set; }

		[ForeignKey("Actuacion")]
		public virtual Actuacionesadm Actuacions { get; set; }

		[ForeignKey("OrganismoReceptor")]
		public virtual OrganismosRef OrganismoReceptors { get; set; }
		#endregion

	}
}
