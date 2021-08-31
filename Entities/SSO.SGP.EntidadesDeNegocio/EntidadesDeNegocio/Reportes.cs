
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
	[MetadataTypeAttribute(typeof(ReportesMetaData))]
	[Table("Reportes")]
	public partial class Reportes
	{
		#region Constructor
		public Reportes()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar NombreDeArchivo")]
		[StringLength(50, ErrorMessage ="NombreDeArchivo no puede superar los 50 caracteres")]
		public string NombreDeArchivo { get; set; }

		public virtual ICollection<ReportesParametros> ReportesParametros { get; set; }
		#endregion

	}
}
