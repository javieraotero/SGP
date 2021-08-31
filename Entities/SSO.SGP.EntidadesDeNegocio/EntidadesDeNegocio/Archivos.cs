
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
	[MetadataTypeAttribute(typeof(ArchivosMetaData))]
	public partial class ArchivosAdjuntos
	{
		#region Constructor
		public ArchivosAdjuntos()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

        public string Path { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }
		#endregion

	}
}
