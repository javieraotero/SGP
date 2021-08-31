
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
	//[MetadataTypeAttribute(typeof(TurnosWebParametrosMetaData))]
	[Table("TurnosWeb")]
	public partial class TurnosWeb
	{
		#region Constructor
		public TurnosWeb()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		public int Organismo { get; set; }

		public DateTime Fecha { get; set; }

		public TimeSpan Hora { get; set; }

		public long DNI { get; set; }

		public string ApellidoYNombre { get; set; }

		public string Telefono { get; set; }
		public string Email { get; set; }
		public bool EsAbogado { get; set; }
		public bool Urgente { get; set; }
		public string Observaciones { get; set; }
		public int Estado { get; set; }

		public bool Contactar { get; set; }

		public bool EsPerito { get; set; }

		public string Expedientes { get; set; }


		#endregion

	}
}
