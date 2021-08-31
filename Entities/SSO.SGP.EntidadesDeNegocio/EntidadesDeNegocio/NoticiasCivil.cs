
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
	[MetadataTypeAttribute(typeof(NoticiasMetaData))]
	[Table("NoticiasCivil")]
	public partial class NoticiasCivil
	{
		#region Constructor
		public NoticiasCivil()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar Titulo")]
		[StringLength(50, ErrorMessage ="Titulo no puede superar los 50 caracteres")]
		public string Titulo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		[StringLength(2147483647, ErrorMessage ="Descripcion no puede superar los 2147483647 caracteres")]
		public string Descripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activo")]
		public bool Activo { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioAlta")]
		public int UsuarioAlta { get; set; }

		public int? Ambito { get; set; }
		#endregion

	}
}
