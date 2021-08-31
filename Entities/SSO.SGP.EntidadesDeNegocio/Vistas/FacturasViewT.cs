using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class FacturasViewT
	{
			#region Propiedades

			[Display(Name = "Id", AutoGenerateField=false)]
			public int Id { get; set; }

			[Display(Name = "Número")]
			public string NumeroDeFactura { get; set; }

			[Display(Name = "Identificación")]
			public int IdentificacionDeFactura { get; set; }

			[Display(Name = "Tipo")]
			public string Tipo { get; set; }

			[Display(Name = "Expediente", AutoGenerateField = false)]
			public int? Expediente { get; set; }

			[Display(Name = "Proveedor")]
			public string Proveedor { get; set; }

			[Display(Name = "Fecha")]
			public DateTime Fecha { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "Importe")]
			public decimal Importe { get; set; }

			#endregion


	}
}
