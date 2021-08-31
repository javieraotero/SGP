
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
	[MetadataTypeAttribute(typeof(CoMediadoresContadoresMetaData))]
	[Table("CoMediadoresContadores")]
	public partial class CoMediadoresContadores
	{
		#region Constructor
		public CoMediadoresContadores()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Inscripcion")]
		public int Inscripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Contador")]
		public int Contador { get; set; }

		[Required(ErrorMessage = "Debe ingresar Circunscripcion")]
		public int Circunscripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activo")]
		public bool Activo { get; set; }

		[ForeignKey("Inscripcion")]
		public virtual CoMediadoresInscripcion Inscripcions { get; set; }

		[ForeignKey("Circunscripcion")]
		public virtual CircunscripcionesRef Circunscripcions { get; set; }
		#endregion

	}
}
