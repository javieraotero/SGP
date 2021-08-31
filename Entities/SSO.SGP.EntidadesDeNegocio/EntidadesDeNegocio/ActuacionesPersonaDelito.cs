
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
	[MetadataTypeAttribute(typeof(ActuacionesPersonaDelitoMetaData))]
	[Table("ActuacionesPersonaDelito")]
	public partial class ActuacionesPersonaDelito
	{
		#region Constructor
		public ActuacionesPersonaDelito()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Actuacion")]
		public int Actuacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Persona")]
		public int Persona { get; set; }

		[Required(ErrorMessage = "Debe ingresar Delito")]
		public int Delito { get; set; }

		[Required(ErrorMessage = "Debe ingresar Automatico")]
		public bool Automatico { get; set; }

		[ForeignKey("Actuacion")]
		public virtual Actuaciones Actuacions { get; set; }

		[ForeignKey("Persona")]
		public virtual ExpedientesPersona Personas { get; set; }

		[ForeignKey("Delito")]
		public virtual ExpedientesDelito Delitos { get; set; }
		#endregion

	}
}
