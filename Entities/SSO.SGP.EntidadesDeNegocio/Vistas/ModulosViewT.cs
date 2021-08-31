using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ModulosViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "Abreviatura")]
			public string Abreviatura { get; set; }

			[Display(Name = "ModuloPadre")]
			public int? ModuloPadre { get; set; }
			#endregion


	}
}
