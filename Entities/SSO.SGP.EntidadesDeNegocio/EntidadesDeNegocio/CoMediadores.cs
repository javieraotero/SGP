
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
	[MetadataTypeAttribute(typeof(CoMediadoresMetaData))]
	[Table("CoMediadores")]
	public partial class CoMediadores
	{
		#region Constructor
		public CoMediadores()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioCarga")]
		public int UsuarioCarga { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaCarga")]
		public DateTime FechaCarga { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioCoMediador")]
		public int UsuarioCoMediador { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activo")]
		public bool Activo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Tipo")]
		public int Tipo { get; set; }

		public virtual ICollection<CoMediadoresInscripcion> CoMediadoresInscripcion { get; set; }

		[ForeignKey("UsuarioCoMediador")]
		public virtual Usuarios UsuarioCoMediadors { get; set; }

		[ForeignKey("Tipo")]
		public virtual MediadoresTipo Tipos { get; set; }
		#endregion

	}
}
