
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
	[MetadataTypeAttribute(typeof(PeritosPeriodoMetaData))]
	[Table("PeritosPeriodo")]
	public partial class PeritosPeriodo
	{
		#region Constructor
		public PeritosPeriodo()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar TipoPeriodo")]
		public int TipoPeriodo { get; set; }

		public DateTime? FecIniInscripcion { get; set; }

		public DateTime? FecFinInscripcion { get; set; }

		public DateTime? FecIniPeriodo { get; set; }

		public DateTime? FecFinPeriodo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activo")]
		public bool Activo { get; set; }

		public virtual ICollection<PeritosInscripcion> PeritosInscripcion { get; set; }

		[ForeignKey("TipoPeriodo")]
		public virtual PeritosTiposPeriodo TipoPeriodos { get; set; }
		#endregion

	}
}
