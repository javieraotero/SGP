
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
	[MetadataTypeAttribute(typeof(CoMediadoresInscripcionMetaData))]
	[Table("CoMediadoresInscripcion")]
	public partial class CoMediadoresInscripcion
	{
		#region Constructor
		public CoMediadoresInscripcion()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		public bool? Circunscripcion1 { get; set; }

		public bool? Circunscripcion2 { get; set; }

		public bool? Circunscripcion3 { get; set; }

		public bool? Circunscripcion4 { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaInscripcion")]
		public DateTime FechaInscripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Especialidad")]
		public int Especialidad { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioCarga")]
		public int UsuarioCarga { get; set; }

		[Required(ErrorMessage = "Debe ingresar Periodo")]
		public int Periodo { get; set; }

		[Required(ErrorMessage = "Debe ingresar CoMediador")]
		public int CoMediador { get; set; }

		[Required(ErrorMessage = "Debe ingresar Estado")]
		public int Estado { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activo")]
		public bool Activo { get; set; }

		public virtual ICollection<CoMediadoresContadores> CoMediadoresContadores { get; set; }

		[ForeignKey("Especialidad")]
		public virtual CoMediadoresEspecialidad Especialidads { get; set; }

		[ForeignKey("Periodo")]
		public virtual MediadoresPeriodo Periodos { get; set; }

		[ForeignKey("CoMediador")]
		public virtual CoMediadores CoMediadors { get; set; }

		[ForeignKey("Estado")]
		public virtual MediadoresInscripcionEstado Estados { get; set; }
		#endregion

	}
}
