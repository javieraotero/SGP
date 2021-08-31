
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
	[MetadataTypeAttribute(typeof(CategoriasExpedientesMetaData))]
	[Table("CategoriasExpedientes")]
	public partial class CategoriasExpedientes
	{
		#region Constructor
		public CategoriasExpedientes()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		[StringLength(100, ErrorMessage ="Descripcion no puede superar los 100 caracteres")]
		public string Descripcion { get; set; }

		public int? SubAmbito { get; set; }

		public int? Circunscripcion { get; set; }

        //public virtual ICollection<ExpedientesCategoriasRel> ExpedientesCategoriasRel { get; set; }

		[ForeignKey("SubAmbito")]
		public virtual Ambitos SubAmbitos { get; set; }

		[ForeignKey("Circunscripcion")]
		public virtual CircunscripcionesRef Circunscripcions { get; set; }
		#endregion

	}
}
