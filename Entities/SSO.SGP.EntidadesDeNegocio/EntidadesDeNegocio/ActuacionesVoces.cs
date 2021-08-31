
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
	[MetadataTypeAttribute(typeof(ActuacionesVocesMetaData))]
	[Table("ActuacionesVoces")]
	public partial class ActuacionesVoces
	{
		#region Constructor
		public ActuacionesVoces()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Actuacion")]
		public int Actuacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Voz")]
		public int Voz { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activo")]
		public bool Activo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Confirmado")]
		public bool Confirmado { get; set; }

		[ForeignKey("Actuacion")]
		public virtual Actuaciones Actuacions { get; set; }

		[ForeignKey("Voz")]
		public virtual Voces Vozs { get; set; }
		#endregion

	}
}
