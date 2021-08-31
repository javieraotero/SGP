
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
	[MetadataTypeAttribute(typeof(PeritosTiposPeriodoMetaData))]
	[Table("PeritosTiposPeriodo")]
	public partial class PeritosTiposPeriodo
	{
		#region Constructor
		public PeritosTiposPeriodo()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[StringLength(50, ErrorMessage ="Descripcion no puede superar los 50 caracteres")]
		public string Descripcion { get; set; }

		public virtual ICollection<PeritosEspecialidad> PeritosEspecialidad { get; set; }

		public virtual ICollection<PeritosPeriodo> PeritosPeriodo { get; set; }
		#endregion

	}
}
