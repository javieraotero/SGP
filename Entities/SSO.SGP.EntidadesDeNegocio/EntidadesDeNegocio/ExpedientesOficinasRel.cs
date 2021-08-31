
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
	[MetadataTypeAttribute(typeof(ExpedientesOficinasRelMetaData))]
	[Table("ExpedientesOficinasRel")]
	public partial class ExpedientesOficinasRel
	{
		#region Constructor
		public ExpedientesOficinasRel()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Required(ErrorMessage = "Debe ingresar Expediente")]
		public int Expediente { get; set; }

		[Required(ErrorMessage = "Debe ingresar Oficina")]
		public int Oficina { get; set; }

		[ForeignKey("Expediente")]
		public virtual Expedientes Expedientes { get; set; }

		[ForeignKey("Oficina")]
		public virtual OrganismosRef Oficinas { get; set; }
		#endregion

	}
}
