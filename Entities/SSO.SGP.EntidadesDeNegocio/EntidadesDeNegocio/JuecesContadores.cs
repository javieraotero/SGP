
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
	[MetadataTypeAttribute(typeof(JuecesContadoresMetaData))]
	[Table("JuecesContadores")]
	public partial class JuecesContadores
	{
		#region Constructor
		public JuecesContadores()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar NivelPonderacion")]
		public int NivelPonderacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Circunscripcion")]
		public int Circunscripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Contador")]
		public int Contador { get; set; }

		[Required(ErrorMessage = "Debe ingresar Juez")]
		public int Juez { get; set; }

		[ForeignKey("Circunscripcion")]
		public virtual CircunscripcionesRef Circunscripcions { get; set; }

		[ForeignKey("Juez")]
		public virtual Usuarios Juezs { get; set; }
		#endregion

	}
}
