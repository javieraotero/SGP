
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
	[MetadataTypeAttribute(typeof(AudienciasDemorasMetaData))]
	[Table("AudienciasDemoras")]
	public partial class AudienciasDemoras
	{
		#region Constructor
		public AudienciasDemoras()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Audiencia")]
		public int Audiencia { get; set; }

		[Required(ErrorMessage = "Debe ingresar MotivoDemora")]
		public int MotivoDemora { get; set; }

		[StringLength(255, ErrorMessage ="Observacion no puede superar los 255 caracteres")]
		public string Observacion { get; set; }

		[ForeignKey("Audiencia")]
		public virtual Audiencias Audiencias { get; set; }

		[ForeignKey("MotivoDemora")]
		public virtual MotivosDemoraRef MotivoDemoras { get; set; }
		#endregion

	}
}
