
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
	[MetadataTypeAttribute(typeof(EstadosIncidentesMetaData))]
	[Table("EstadosIncidentes")]
	public partial class EstadosIncidentes
	{
		#region Constructor
		public EstadosIncidentes()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		[StringLength(50, ErrorMessage ="Descripcion no puede superar los 50 caracteres")]
		public string Descripcion { get; set; }

		[StringLength(60, ErrorMessage ="Icono no puede superar los 60 caracteres")]
		public string Icono { get; set; }

		public virtual ICollection<Incidentes> Incidentes { get; set; }

		public virtual ICollection<IncidentesEstado> IncidentesEstado { get; set; }
		#endregion

	}
}
