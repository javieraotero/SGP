
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
	[MetadataTypeAttribute(typeof(ElementosSecuestradosDocumentoMetaData))]
	[Table("ElementosSecuestradosDocumento")]
	public partial class ElementosSecuestradosDocumento
	{
		#region Constructor
		public ElementosSecuestradosDocumento()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Elemento")]
		public int Elemento { get; set; }

		[Required(ErrorMessage = "Debe ingresar NombreOriginal")]
		[StringLength(255, ErrorMessage ="NombreOriginal no puede superar los 255 caracteres")]
		public string NombreOriginal { get; set; }

		[Required(ErrorMessage = "Debe ingresar Extension")]
		[StringLength(3, ErrorMessage ="Extension no puede superar los 3 caracteres")]
		public string Extension { get; set; }

		[StringLength(255, ErrorMessage ="Descripcion no puede superar los 255 caracteres")]
		public string Descripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar Usuario")]
		public int Usuario { get; set; }

		[Required(ErrorMessage = "Debe ingresar Confirmado")]
		public bool Confirmado { get; set; }

		[ForeignKey("Elemento")]
		public virtual ElementosSecuestrados Elementos { get; set; }

		[ForeignKey("Usuario")]
		public virtual Usuarios Usuarios { get; set; }
		#endregion

	}
}
