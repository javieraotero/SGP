
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
	[MetadataTypeAttribute(typeof(ExpedientesCategoriasRelMetaData))]
	[Table("ExpedientesCategoriasRel")]
	public partial class ExpedientesCategoriasRel
	{
		#region Constructor
		public ExpedientesCategoriasRel()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Categoria { get; set; }

		[Key]
		public int Expediente { get; set; }

		[ForeignKey("Categoria")]
		public virtual CategoriasExpedientes Categorias { get; set; }

		[ForeignKey("Expediente")]
		public virtual Expedientes Expedientes { get; set; }
		#endregion

	}
}
