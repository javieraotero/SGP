
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
	[MetadataTypeAttribute(typeof(UsuariosAccesosMetaData))]
	[Table("UsuariosAccesos")]
	public partial class UsuariosAccesos
	{
		#region Constructor
		public UsuariosAccesos()
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

		[Required(ErrorMessage = "Debe ingresar Ip")]
		[StringLength(15, ErrorMessage ="Ip no puede superar los 15 caracteres")]
		public string Ip { get; set; }

		[Required(ErrorMessage = "Debe ingresar Intentos")]
		public int Intentos { get; set; }

		[StringLength(100, ErrorMessage ="Navegador no puede superar los 100 caracteres")]
		public string Navegador { get; set; }

		public int? Organismo { get; set; }

		[ForeignKey("Usuario")]
		public virtual Usuarios Usuarios { get; set; }
		#endregion

	}
}
