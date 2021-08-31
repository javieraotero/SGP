
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
	[MetadataTypeAttribute(typeof(ExpedientesSumariantesRelMetaData))]
	[Table("ExpedientesSumariantesRel")]
	public partial class ExpedientesSumariantesRel
	{
		#region Constructor
		public ExpedientesSumariantesRel()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Required(ErrorMessage = "Debe ingresar Expediente")]
		public int Expediente { get; set; }

		[Required(ErrorMessage = "Debe ingresar Usuario")]
		public int Usuario { get; set; }

		[ForeignKey("Expediente")]
		public virtual Expedientes Expedientes { get; set; }

		[ForeignKey("Usuario")]
		public virtual Usuarios Usuarios { get; set; }
		#endregion

	}
}
