
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
	[MetadataTypeAttribute(typeof(MediadoresTipoMetaData))]
	[Table("MediadoresTipo")]
	public partial class MediadoresTipo
	{
		#region Constructor
		public MediadoresTipo()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[StringLength(50, ErrorMessage ="Descripcion no puede superar los 50 caracteres")]
		public string Descripcion { get; set; }

		public virtual ICollection<CoMediadores> CoMediadoresTiposMediadores1 { get; set; }

		public virtual ICollection<Mediadores> MediadoresTiposMediadores { get; set; }
		#endregion

	}
}
