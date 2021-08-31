using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class TiposAudienciaRefView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "EnUso")]
			public bool EnUso { get; set; }

			[Display(Name = "Juicio")]
			public bool Juicio { get; set; }

			[Display(Name = "RelevarControl")]
			public int RelevarControl { get; set; }

			[Display(Name = "Ambito")]
			public int Ambito { get; set; }

			[Display(Name = "NotificaPresidenteAudiencia")]
			public bool NotificaPresidenteAudiencia { get; set; }
			#endregion


	}
}
