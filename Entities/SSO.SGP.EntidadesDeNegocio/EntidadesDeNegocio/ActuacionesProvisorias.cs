
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
	[MetadataTypeAttribute(typeof(ActuacionesProvisoriasMetaData))]
	[Table("ActuacionesProvisorias")]
	public partial class ActuacionesProvisorias
	{
		#region Constructor
		public ActuacionesProvisorias()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fecha")]
		public DateTime Fecha { get; set; }

		[Required(ErrorMessage = "Debe ingresar Actuacion")]
		public int Actuacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fundamento")]
		[StringLength(2147483647, ErrorMessage ="Fundamento no puede superar los 2147483647 caracteres")]
		public string Fundamento { get; set; }

		[Required(ErrorMessage = "Debe ingresar Usuario")]
		public int Usuario { get; set; }
		#endregion

	}
}
