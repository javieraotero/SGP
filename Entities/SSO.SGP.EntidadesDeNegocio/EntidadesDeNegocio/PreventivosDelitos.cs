
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
	[MetadataTypeAttribute(typeof(PreventivosDelitosMetaData))]
	[Table("PreventivosDelitos")]
	public partial class PreventivosDelitos
	{
		#region Constructor
		public PreventivosDelitos()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Preventivo")]
		public int Preventivo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Delito")]
		public int Delito { get; set; }

		[Required(ErrorMessage = "Debe ingresar Tentativa")]
		public bool Tentativa { get; set; }

		[Required(ErrorMessage = "Debe ingresar Flagrancia")]
		public bool Flagrancia { get; set; }

		[ForeignKey("Preventivo")]
		public virtual Preventivos Preventivos { get; set; }

		[ForeignKey("Delito")]
		public virtual DelitosRef Delitos { get; set; }
		#endregion

	}
}
