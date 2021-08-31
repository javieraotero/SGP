using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class LicenciasAgenteExcepcionesViewT
    {
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Licencia")]
			public string Licencia { get; set; }

			[Display(Name = "Fecha Fin")]
			public DateTime FechaFin{ get; set; }

			[Display(Name = "Resolucion")]
			public string Resolucion { get; set; }

			[Display(Name = "Dias")]
			public int Dias { get; set; }

			#endregion


	}
}
