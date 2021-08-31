
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
	[MetadataTypeAttribute(typeof(SucesosReceptoriaMetaData))]
	[Table("SucesosReceptoria")]
	public partial class SucesosReceptoria
	{
		#region Constructor
		public SucesosReceptoria()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		public DateTime? Fecha { get; set; }

		[StringLength(1, ErrorMessage ="Tipo no puede superar los 1 caracteres")]
		public string Tipo { get; set; }

		[StringLength(8000, ErrorMessage ="Descripcion no puede superar los 8000 caracteres")]
		public string Descripcion { get; set; }

		public int? Usuario { get; set; }
		#endregion

	}
}
