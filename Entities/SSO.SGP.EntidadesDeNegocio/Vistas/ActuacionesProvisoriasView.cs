using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ActuacionesProvisoriasView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Fecha")]
			public DateTime Fecha { get; set; }

			[Display(Name = "Actuacion")]
			public int Actuacion { get; set; }

			[Display(Name = "Fundamento")]
			public string Fundamento { get; set; }

			[Display(Name = "Usuario")]
			public int Usuario { get; set; }
			#endregion


	}
}
