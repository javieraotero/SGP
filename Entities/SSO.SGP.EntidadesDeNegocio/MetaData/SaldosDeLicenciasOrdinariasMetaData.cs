using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class SaldosDeLicenciasOrdinariasMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Agente")]
			public int Agente { get; set; }

			[Display(Name = "Anio")]
			public int Anio { get; set; }

			[Display(Name = "DiasTrabajados")]
			public int DiasTrabajados { get; set; }

			[Display(Name = "DiasUtilizados")]
			public int DiasUtilizados { get; set; }

			[Display(Name = "Enero")]
			public bool Enero { get; set; }

			[Display(Name = "Julio")]
			public bool Julio { get; set; }
			#endregion


	}
}
