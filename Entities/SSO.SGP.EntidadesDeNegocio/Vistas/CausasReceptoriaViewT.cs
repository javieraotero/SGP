using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class CausasReceptoriaViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Numero")]
			public int Numero { get; set; }

			[Display(Name = "Caratula")]
			public string Caratula { get; set; }

			[Display(Name = "Circunscripcion")]
			public int Circunscripcion { get; set; }
			#endregion


	}
}
