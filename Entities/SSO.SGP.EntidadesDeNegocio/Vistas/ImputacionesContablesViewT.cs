using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ImputacionesContablesViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "ExpedienteAImputar")]
			public int ExpedienteAImputar { get; set; }

			[Display(Name = "Fecha")]
			public DateTime Fecha { get; set; }

			[Display(Name = "UsuarioAlta")]
			public int UsuarioAlta { get; set; }

			[Display(Name = "FechaElimina")]
			public DateTime FechaElimina { get; set; }

			[Display(Name = "Operacion")]
			public int Operacion { get; set; }

			[Display(Name = "ExpedienteIndirecto")]
			public int? ExpedienteIndirecto { get; set; }
			#endregion


	}
}
