
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
	[MetadataTypeAttribute(typeof(TraceProduccionMetaData))]
	[Table("TraceProduccion")]
	public partial class TraceProduccion
	{
		#region Constructor
		public TraceProduccion()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int RowNumber { get; set; }

		public int? EventClass { get; set; }

		[StringLength(1073741823, ErrorMessage ="TextData no puede superar los 1073741823 caracteres")]
		public string TextData { get; set; }

		[StringLength(128, ErrorMessage ="ApplicationName no puede superar los 128 caracteres")]
		public string ApplicationName { get; set; }

		[StringLength(128, ErrorMessage ="NTUserName no puede superar los 128 caracteres")]
		public string NTUserName { get; set; }

		[StringLength(128, ErrorMessage ="LoginName no puede superar los 128 caracteres")]
		public string LoginName { get; set; }

		public int? CPU { get; set; }

		public long? Reads { get; set; }

		public long? Writes { get; set; }

		public long? Duration { get; set; }

		public int? ClientProcessID { get; set; }

		public int? SPID { get; set; }

		public DateTime? StartTime { get; set; }

		public DateTime? EndTime { get; set; }

		#endregion

	}
}
