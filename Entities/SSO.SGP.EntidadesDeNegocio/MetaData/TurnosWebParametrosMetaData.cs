using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class TurnosWebParametrosMetaData
	{
		#region Propiedades
		
		public int Id { get; set; }

		public int Organismo { get; set; }

		public TimeSpan HoraDeInicio { get; set; }

		public TimeSpan HoraDeFin { get; set; }

		public int Intervalo { get; set; }

		public int TurnosPorIntervalo { get; set; }
		#endregion


	}
}
