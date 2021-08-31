
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
	[Table("PersonasTrazabilidad")]
	public partial class PersonasTrazabilidad
	{
		#region Constructor
		public PersonasTrazabilidad()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		public int Organismo { get; set; }

		public DateTime FechaAlta { get; set; }

		public int Persona { get; set; }

		public DateTime Fecha { get; set; }

		public int Usuario { get; set; }

		public TimeSpan Hora { get; set; }

		#endregion

	}
}
