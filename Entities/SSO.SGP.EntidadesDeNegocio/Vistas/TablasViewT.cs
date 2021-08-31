using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class TablasViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Nombre")]
			public string Nombre { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "DelSistema")]
			public bool DelSistema { get; set; }

			[Display(Name = "SoloLectura")]
			public bool SoloLectura { get; set; }

			[Display(Name = "Clase")]
			public string Clase { get; set; }

			[Display(Name = "HabilitarEliminacion")]
			public bool HabilitarEliminacion { get; set; }

			[Display(Name = "Orden")]
			public string Orden { get; set; }

			[Display(Name = "AdministrarPorGenerico")]
			public bool AdministrarPorGenerico { get; set; }
			#endregion


	}
}
