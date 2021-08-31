
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
	[MetadataTypeAttribute(typeof(PreventivosPersonaMetaData))]
	[Table("PreventivosPersona")]
	public partial class PreventivosPersona
	{
		#region Constructor
		public PreventivosPersona()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Preventivo")]
		public int Preventivo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Persona")]
		public int Persona { get; set; }

		[Required(ErrorMessage = "Debe ingresar Rol")]
		public int Rol { get; set; }

		[Required(ErrorMessage = "Debe ingresar Demorado")]
		public bool Demorado { get; set; }

		[ForeignKey("Preventivo")]
		public virtual Preventivos Preventivos { get; set; }

		[ForeignKey("Persona")]
		public virtual Personas Personas { get; set; }

		[ForeignKey("Rol")]
		public virtual RolesPersonaRef Rols { get; set; }
		#endregion

	}
}
