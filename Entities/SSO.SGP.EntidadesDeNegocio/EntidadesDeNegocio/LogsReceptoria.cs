
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
	[MetadataTypeAttribute(typeof(LogsReceptoriaMetaData))]
	[Table("LogsReceptoria")]
	public partial class LogsReceptoria
	{
		#region Constructor
		public LogsReceptoria()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Numero")]
		public int Numero { get; set; }

		[Required(ErrorMessage = "Debe ingresar Juzgado")]
		[StringLength(7, ErrorMessage ="Juzgado no puede superar los 7 caracteres")]
		public string Juzgado { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fecha")]
		public DateTime Fecha { get; set; }

		[Required(ErrorMessage = "Debe ingresar Categoria")]
		[StringLength(1, ErrorMessage ="Categoria no puede superar los 1 caracteres")]
		public string Categoria { get; set; }

		[Required(ErrorMessage = "Debe ingresar Contadores")]
		[StringLength(255, ErrorMessage ="Contadores no puede superar los 255 caracteres")]
		public string Contadores { get; set; }

		[StringLength(50, ErrorMessage ="IdCategoria no puede superar los 50 caracteres")]
		public string IdCategoria { get; set; }
		#endregion

	}
}
