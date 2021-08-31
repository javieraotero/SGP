using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ImagenesrrhhViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Nombre")]
			public string Nombre { get; set; }

			[Display(Name = "Categoria")]
			public int Categoria { get; set; }

			[Display(Name = "FechaDeCarga")]
			public DateTime FechaDeCarga { get; set; }

			[Display(Name = "FechaUltimaActualizacion")]
			public DateTime FechaUltimaActualizacion { get; set; }

			[Display(Name = "Usuario")]
			public int Usuario { get; set; }

			[Display(Name = "Agente")]
			public int Agente { get; set; }

			[Display(Name = "Imagen")]
			public string Imagen { get; set; }

			[Display(Name = "Firma")]
			public string Firma { get; set; }
			#endregion


	}
}
