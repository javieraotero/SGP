using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class FacturasImputadasDetalleMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "FacturaImputada")]
			public int FacturaImputada { get; set; }

			[Display(Name = "Partida")]
			public int Partida { get; set; }

			[Display(Name = "Division")]
			public int Division { get; set; }

			[Display(Name = "Importe")]
			public decimal Importe { get; set; }
			#endregion


	}
}
