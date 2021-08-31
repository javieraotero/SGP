
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
	[MetadataTypeAttribute(typeof(PeritosSorteoMetaData))]
	[Table("PeritosSorteo")]
	public partial class PeritosSorteo
	{
		#region Constructor
		public PeritosSorteo()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Inscripcion")]
		public int Inscripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Organismo")]
		public int Organismo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Caratula")]
		[StringLength(150, ErrorMessage ="Caratula no puede superar los 150 caracteres")]
		public string Caratula { get; set; }

		[Required(ErrorMessage = "Debe ingresar Oficio")]
		[StringLength(13, ErrorMessage ="Oficio no puede superar los 13 caracteres")]
		public string Oficio { get; set; }

		[Required(ErrorMessage = "Debe ingresar NroExpediente")]
		[StringLength(15, ErrorMessage ="NroExpediente no puede superar los 15 caracteres")]
		public string NroExpediente { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fecha")]
		public DateTime Fecha { get; set; }

		public int? UsuarioSorteo { get; set; }

		[ForeignKey("Inscripcion")]
		public virtual PeritosInscripcion Inscripcions { get; set; }

		[ForeignKey("Organismo")]
		public virtual OrganismosRef Organismos { get; set; }

		[ForeignKey("UsuarioSorteo")]
		public virtual Usuarios UsuarioSorteos { get; set; }
		#endregion

	}
}
