using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class NombramientosMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Agente")]
			public int Agente { get; set; }

			[Display(Name = "Fecha de Alta")]
			public DateTime FechaDeAlta { get; set; }

			[Display(Name = "Fecha de Baja")]
			public DateTime? FechaDeBaja { get; set; }

			[Display(Name = "Motivo")]
			public string Motivo { get; set; }

			[Display(Name = "Organismo")]
			public int Organismo { get; set; }

			[Display(Name = "Cargo")]
			public int Cargo { get; set; }

			[Display(Name = "Sit. Revista")]
			public string SituacionRevista { get; set; }

			[Display(Name = "Fin de Contrato")]
			public DateTime? FechaFinContrato { get; set; }

			[Display(Name = "Fin Sustitución")]
			public DateTime? FechaFinSustitucion { get; set; }

			[Display(Name = "Renuncia")]
			public DateTime? FechaRenuncia { get; set; }

			[Display(Name = "Pase A Planta")]
			public DateTime? FechaPaseAPlanta { get; set; }

			[Display(Name = "Ultimo Ascenso")]
			public DateTime? FechaUltimoAscenso { get; set; }
			#endregion


	}
}
