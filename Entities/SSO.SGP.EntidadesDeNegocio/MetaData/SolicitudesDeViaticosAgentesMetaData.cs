using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class SolicitudesDeViaticosAgentesMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "SolicitudDeViatico")]
			public int SolicitudDeViatico { get; set; }

			[Display(Name = "Agente")]
			public int Agente { get; set; }

			[Display(Name = "Dias")]
			public int Dias { get; set; }

			[Display(Name = "ImportePorDia")]
			public decimal ImportePorDia { get; set; }

			[Display(Name = "Subtotal")]
			public decimal Subtotal { get; set; }

			[Display(Name = "ImporteGastos")]
			public decimal ImporteGastos { get; set; }

			[Display(Name = "ImporteTotal")]
			public decimal ImporteTotal { get; set; }
			#endregion


	}
}
