
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
	[MetadataTypeAttribute(typeof(MediadoresPeriodosTipoMetaData))]
	[Table("MediadoresPeriodosTipo")]
	public partial class MediadoresPeriodosTipo
	{
		#region Constructor
		public MediadoresPeriodosTipo()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[StringLength(50, ErrorMessage ="Descripcion no puede superar los 50 caracteres")]
		public string Descripcion { get; set; }

		public virtual ICollection<MediadoresPeriodo> MediadoresPeriodo { get; set; }
		#endregion

	}
}
