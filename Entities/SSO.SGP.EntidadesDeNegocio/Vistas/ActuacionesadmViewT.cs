using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ActuacionesadmViewT
	{
			#region Propiedades

			[Display(Name = "Id", Order = 0)]
			public int Id { get; set; }

			[Display(Name = "Descripción", Order = 35)]
			public string Descripcion { get; set; }

			[Display(Name = "Fecha", Order = 10)]
			public DateTime Fecha { get; set; }

			[Display(Name = "FechaPublicacion", Order=10)]
			public DateTime? FechaPublicacion { get; set; }

			[Display(Name = "TipoActuacion", Order=15)]
			public string TipoActuacion { get; set; }

			[Display(Name = "Cargo", Order = 20)]
			public string SubAmbitoCargo { get; set; }

			[Display(Name = "Fojas", Order = 5)]
			public int Fojas { get; set; }

            [Display(Name = "Expediente", Order = 5)]
            public int Expediente { get; set; }

            [Display(Name = "Numero", Order = 5)]
            public string Numero { get; set; }

        #endregion


    }
}
