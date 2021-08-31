
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
	[MetadataTypeAttribute(typeof(PeritosEspecialidadMetaData))]
	[Table("PeritosEspecialidad")]
	public partial class PeritosEspecialidad
	{
		#region Constructor
		public PeritosEspecialidad()
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

		[Required(ErrorMessage = "Debe ingresar Activo")]
		public bool Activo { get; set; }

		[Required(ErrorMessage = "Debe ingresar SubEspecialidad")]
		public bool SubEspecialidad { get; set; }

		[Required(ErrorMessage = "Debe ingresar TipoPeriodo")]
		public int TipoPeriodo { get; set; }

		public virtual ICollection<PeritosInscripcion> PeritosInscripcion { get; set; }

		[ForeignKey("TipoPeriodo")]
		public virtual PeritosTiposPeriodo TipoPeriodos { get; set; }
		#endregion

	}
}
