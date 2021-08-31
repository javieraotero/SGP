
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
	[MetadataTypeAttribute(typeof(PersonasParentescosMetaData))]
	[Table("PersonasParentescos")]
	public partial class PersonasParentescos
	{
		#region Constructor
		public PersonasParentescos()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Persona1")]
		public int Persona1 { get; set; }

		[Required(ErrorMessage = "Debe ingresar Persona2")]
		public int Persona2 { get; set; }

		[Required(ErrorMessage = "Debe ingresar TipoParentesco")]
		public int TipoParentesco { get; set; }

		[ForeignKey("Persona1")]
		public virtual Personas Persona1s { get; set; }

		[ForeignKey("Persona2")]
		public virtual Personas Persona2s { get; set; }

		[ForeignKey("TipoParentesco")]
		public virtual TiposParentescosRef TipoParentescos { get; set; }
		#endregion

	}
}
