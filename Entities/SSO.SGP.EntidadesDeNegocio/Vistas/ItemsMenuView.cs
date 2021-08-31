using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ItemsMenuView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "ItemPadre")]
			public int? ItemPadre { get; set; }

			[Display(Name = "Parametros")]
			public string Parametros { get; set; }

			[Display(Name = "Imagen")]
			public string Imagen { get; set; }

			[Display(Name = "Tooltip")]
			public string Tooltip { get; set; }

			[Display(Name = "MostrarEnBarra")]
			public bool MostrarEnBarra { get; set; }

			[Display(Name = "Camino")]
			public string Camino { get; set; }

			[Display(Name = "Orden")]
			public int Orden { get; set; }

			[Display(Name = "Modulo")]
			public int Modulo { get; set; }

			[Display(Name = "Formulario")]
			public int? Formulario { get; set; }
			#endregion


	}
}
