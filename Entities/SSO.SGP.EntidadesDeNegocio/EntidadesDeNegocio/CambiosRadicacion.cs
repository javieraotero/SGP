
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
	[MetadataTypeAttribute(typeof(CambiosRadicacionMetaData))]
	[Table("CambiosRadicacion")]
	public partial class CambiosRadicacion
	{
		#region Constructor
		public CambiosRadicacion()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fecha")]
		public DateTime Fecha { get; set; }

		[Required(ErrorMessage = "Debe ingresar Causa")]
		public int Causa { get; set; }

		[Required(ErrorMessage = "Debe ingresar Juzgado")]
		public int Juzgado { get; set; }

		[ForeignKey("Causa")]
		public virtual Causas Causas { get; set; }

		[ForeignKey("Juzgado")]
		public virtual OrganismosRef Juzgados { get; set; }
		#endregion

	}
}
