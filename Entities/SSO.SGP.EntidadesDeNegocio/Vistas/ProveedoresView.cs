using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ProveedoresView
	{
			#region Propiedades

			[Display(Name = "Id", Order=0)]
			public int Id { get; set; }

			[Display(Name = "Nombre", Order=20)]
			public string Nombre { get; set; }

			[Display(Name = "RazonSocial", Order = 20)]
			public string RazonSocial { get; set; }

			[Display(Name = "DomicilioReal", Order = 10)]
			public string DomicilioReal { get; set; }

			[Display(Name = "CodigoPostal", Order = 5)]
			public int? CodigoPostal { get; set; }

			[Display(Name = "CUIT", Order = 7)]
			public string CUIT { get; set; }

			[Display(Name = "IngresosBrutos", Order = 10)]
			public string IngresosBrutos { get; set; }

			[Display(Name = "Estado", Order =5)]
			public string Estado { get; set; }

			#endregion


	}
}
