
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
	[MetadataTypeAttribute(typeof(TurnosWebParametrosMetaData))]
	[Table("TurnosWebParametros")]
	public partial class TurnosWebParametros
	{
		#region Constructor
		public TurnosWebParametros()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }
				
		public int Organismo { get; set; }

		public TimeSpan HoraDeInicio { get; set; }

		public TimeSpan HoraDeFin { get; set; }

		public int Intervalo { get; set; }

		public int TurnosPorIntervalo { get; set; }

		public bool SoloMensaje { get; set; }

		public bool SoloAbogado { get; set; }
		public string Ayuda { get; set; }

		public int Orden { get; set; }

		public int Localidad { get; set; }

		public int? AbogadosPorDia { get; set; }

		public string DescripcionCorta { get; set; }
		
		#endregion

	}
}
