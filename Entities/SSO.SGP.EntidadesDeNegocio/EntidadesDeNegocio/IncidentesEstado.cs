
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
	[MetadataTypeAttribute(typeof(IncidentesEstadoMetaData))]
	[Table("IncidentesEstado")]
	public partial class IncidentesEstado
	{
		#region Constructor
		public IncidentesEstado()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Incidente")]
		public int Incidente { get; set; }

		[Required(ErrorMessage = "Debe ingresar Estado")]
		public int Estado { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaHora")]
		public DateTime FechaHora { get; set; }

		[Required(ErrorMessage = "Debe ingresar Usuario")]
		public int Usuario { get; set; }

		[StringLength(2147483647, ErrorMessage ="Observaciones no puede superar los 2147483647 caracteres")]
		public string Observaciones { get; set; }

		public int? DiasTranscurridos { get; set; }

		[ForeignKey("Incidente")]
		public virtual Incidentes Incidentes { get; set; }

		[ForeignKey("Estado")]
		public virtual EstadosIncidentes Estados { get; set; }

		[ForeignKey("Usuario")]
		public virtual Usuarios Usuarios { get; set; }
		#endregion

	}
}
