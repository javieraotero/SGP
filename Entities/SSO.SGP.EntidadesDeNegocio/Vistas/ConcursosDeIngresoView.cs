using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ConcursosDeIngresoView
	{
			#region Propiedades

			[Display(Name = "Id", Order =0)]
			public int Id { get; set; }

			[Display(Name = "Nombre", Order =15)]
			public string Nombre { get; set; }

			[Display(Name = "Descripcion", Order = 25)]
			public string Descripcion { get; set; }

			[Display(Name = "Inicio", Order = 10)]
			public DateTime FechaInicio { get; set; }

			[Display(Name = "Fin", Order = 10)]
			public DateTime FechaFin { get; set; }

			[Display(Name = "Organismo", Order =15)]
			public string Organismo { get; set; }

			[Display(Name = "Cargo", Order =10)]
			public string Cargo { get; set; }

            [Display(Name = "Tipo", Order = 10)]
            public string Tipo { get; set; }

        #endregion


    }
}
