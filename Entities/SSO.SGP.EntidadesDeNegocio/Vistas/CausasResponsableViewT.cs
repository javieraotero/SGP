using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class CausasResponsableViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Causa")]
			public int Causa { get; set; }

			[Display(Name = "Fecha")]
			public DateTime Fecha { get; set; }

			[Display(Name = "Responsable")]
			public int Responsable { get; set; }

			[Display(Name = "Cargo")]
			public int Cargo { get; set; }

			[Display(Name = "Rol")]
			public int Rol { get; set; }

			[Display(Name = "UsuarioAsignacion")]
			public int UsuarioAsignacion { get; set; }

			[Display(Name = "Observaciones")]
			public string Observaciones { get; set; }

			[Display(Name = "PorSorteo")]
			public bool PorSorteo { get; set; }
			#endregion


	}
}
