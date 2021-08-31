
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
	[MetadataTypeAttribute(typeof(MediadoresMetaData))]
	[Table("Mediadores")]
	public partial class Mediadores
	{
		#region Constructor
		public Mediadores()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioCarga")]
		public int UsuarioCarga { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioMediador")]
		public int UsuarioMediador { get; set; }

		[Required(ErrorMessage = "Debe ingresar EspecialidadEnFamilia")]
		public bool EspecialidadEnFamilia { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activo")]
		public bool Activo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Tipo")]
		public int Tipo { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaCarga")]
		public DateTime FechaCarga { get; set; }

		public virtual ICollection<MediadoresInscripcion> MediadoresInscripcion { get; set; }

		[ForeignKey("UsuarioMediador")]
		public virtual Usuarios UsuarioMediadors { get; set; }

		[ForeignKey("Tipo")]
		public virtual MediadoresTipo Tipos { get; set; }
		#endregion

	}
}
