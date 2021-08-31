using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ParametrosReceptoriaView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "Valor")]
			public string Valor { get; set; }

			[Display(Name = "Tipo")]
			public string Tipo { get; set; }

			[Display(Name = "ExpresionRegular")]
			public string ExpresionRegular { get; set; }
			#endregion


	}
}
