using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class SucesosReceptoriaView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Fecha")]
			public DateTime? Fecha { get; set; }

			[Display(Name = "Tipo")]
			public string Tipo { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "Usuario")]
			public int? Usuario { get; set; }
			#endregion


	}
}
