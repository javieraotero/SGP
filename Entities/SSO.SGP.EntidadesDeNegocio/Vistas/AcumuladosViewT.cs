using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class AcumuladosViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Juzgado")]
			public int Juzgado { get; set; }

			[Display(Name = "Categoria")]
			public int Categoria { get; set; }

			[Display(Name = "Habilitado")]
			public bool Habilitado { get; set; }

			[Display(Name = "Cantidad")]
			public int Cantidad { get; set; }

			[Display(Name = "Circunscripcion")]
			public int Circunscripcion { get; set; }
			#endregion


	}
}
