
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
	[MetadataTypeAttribute(typeof(PeritosContadoresMetaData))]
	[Table("PeritosContadores")]
	public partial class PeritosContadores
	{
		#region Constructor
		public PeritosContadores()
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

		[Required(ErrorMessage = "Debe ingresar Organismo")]
		public int Organismo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activo")]
		public bool Activo { get; set; }

		[ForeignKey("Inscripcion")]
		public virtual PeritosInscripcion Inscripcions { get; set; }

		[ForeignKey("Organismo")]
		public virtual OrganismosRef Organismos { get; set; }
		#endregion

	}
}
