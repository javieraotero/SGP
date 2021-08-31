
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
	[MetadataTypeAttribute(typeof(UsuariosCambiosClaveMetaData))]
	[Table("UsuariosCambiosClave")]
	public partial class UsuariosCambiosClave
	{
		#region Constructor
		public UsuariosCambiosClave()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Usuario")]
		public int Usuario { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fecha")]
		public DateTime Fecha { get; set; }

		[Required(ErrorMessage = "Debe ingresar ClaveAnterior")]
		[StringLength(40, ErrorMessage ="ClaveAnterior no puede superar los 40 caracteres")]
		public string ClaveAnterior { get; set; }

		[ForeignKey("Usuario")]
		public virtual Usuarios Usuarios { get; set; }
		#endregion

	}
}
