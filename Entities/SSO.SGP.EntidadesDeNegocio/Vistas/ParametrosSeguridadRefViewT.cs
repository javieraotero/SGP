using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ParametrosSeguridadRefViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "CambioClavePrimerInicio")]
			public bool CambioClavePrimerInicio { get; set; }

			[Display(Name = "LongitudMinimaClave")]
			public int LongitudMinimaClave { get; set; }

			[Display(Name = "ClavesAlfanumericasObligatorias")]
			public bool ClavesAlfanumericasObligatorias { get; set; }

			[Display(Name = "IntervaloCaducidadClave")]
			public int IntervaloCaducidadClave { get; set; }

			[Display(Name = "MaximoIntentosAccesoFallidos")]
			public int MaximoIntentosAccesoFallidos { get; set; }

			[Display(Name = "DiasInactividadBloqueo")]
			public int DiasInactividadBloqueo { get; set; }

			[Display(Name = "ClavesEnRegistroHistorico")]
			public int ClavesEnRegistroHistorico { get; set; }

			[Display(Name = "Activo")]
			public bool Activo { get; set; }
			#endregion


	}
}
