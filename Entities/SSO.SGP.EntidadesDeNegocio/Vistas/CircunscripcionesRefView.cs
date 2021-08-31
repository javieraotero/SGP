using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class CircunscripcionesRefView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "Abreviatura")]
			public string Abreviatura { get; set; }

			[Display(Name = "UltimoExpediente")]
			public int UltimoExpediente { get; set; }

			[Display(Name = "CircunscripcionOJ")]
			public int CircunscripcionOJ { get; set; }

			[Display(Name = "UltimaNotificacion")]
			public int UltimaNotificacion { get; set; }

			[Display(Name = "ReceptoriaSorteaCausa")]
			public bool ReceptoriaSorteaCausa { get; set; }

			[Display(Name = "MediacionCivil")]
			public bool MediacionCivil { get; set; }

			[Display(Name = "CircunscripcionArchiva")]
			public int CircunscripcionArchiva { get; set; }

			[Display(Name = "NotificaPolicia")]
			public bool NotificaPolicia { get; set; }

			[Display(Name = "ReceptoriaUnica")]
			public bool ReceptoriaUnica { get; set; }
			#endregion


	}
}
