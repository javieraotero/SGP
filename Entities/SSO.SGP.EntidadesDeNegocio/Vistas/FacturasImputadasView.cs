using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class FacturasImputadasView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Factura")]
			public int Factura { get; set; }

			[Display(Name = "Fecha")]
			public DateTime Fecha { get; set; }

			[Display(Name = "AnioContable")]
			public int AnioContable { get; set; }

			[Display(Name = "Usuario")]
			public int Usuario { get; set; }

			[Display(Name = "FechaElimina")]
			public DateTime? FechaElimina { get; set; }

			[Display(Name = "UsuarioElimina")]
			public int? UsuarioElimina { get; set; }
			#endregion


	}
}
