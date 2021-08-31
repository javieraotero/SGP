using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ControlPresentacionesView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "ExpedientePersona")]
			public int ExpedientePersona { get; set; }

			[Display(Name = "FechaPresentacion")]
			public DateTime FechaPresentacion { get; set; }

			[Display(Name = "Firma")]
			public bool Firma { get; set; }

			[Display(Name = "Observaciones")]
			public string Observaciones { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime FechaAlta { get; set; }

			[Display(Name = "UsuarioAlta")]
			public int UsuarioAlta { get; set; }

			[Display(Name = "FechaModificacion")]
			public DateTime FechaModificacion { get; set; }

			[Display(Name = "UsuarioModifica")]
			public int UsuarioModifica { get; set; }
			#endregion


	}
}
