using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class PeritosSorteoViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Inscripcion")]
			public int Inscripcion { get; set; }

			[Display(Name = "Organismo")]
			public int Organismo { get; set; }

			[Display(Name = "Caratula")]
			public string Caratula { get; set; }

			[Display(Name = "Oficio")]
			public string Oficio { get; set; }

			[Display(Name = "NroExpediente")]
			public string NroExpediente { get; set; }

			[Display(Name = "Fecha")]
			public DateTime Fecha { get; set; }

			[Display(Name = "UsuarioSorteo")]
			public int? UsuarioSorteo { get; set; }
			#endregion


	}
}
