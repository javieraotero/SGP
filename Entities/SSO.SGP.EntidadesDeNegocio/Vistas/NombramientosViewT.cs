using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class NombramientosViewT
	{
			#region Propiedades

			[Display(Name = "Id", AutoGenerateField=false)]
			public int Id { get; set; }

			[Display(Name = "Agente")]
			public int Agente { get; set; }

			[Display(Name = "Fecha Alta")]
			public DateTime FechaDeAlta { get; set; }

			[Display(Name = "Fecha Baja")]
			public DateTime? FechaDeBaja { get; set; }

            [Display(Name = "U.Ascenso")]
            public DateTime? FechaUltimoAscenso { get; set; }

			[Display(Name = "Organismo")]
			public string Organismo { get; set; }

            [Display(Name = "SR")]
            public string SituacionRevista { get; set; }

			[Display(Name = "Cargo")]
			public string Cargo { get; set; }

            //[Display(Name = "SituacionRevista")]
            //public string SituacionRevista { get; set; }

            //[Display(Name = "FechaFinContrato")]
            //public DateTime? FechaFinContrato { get; set; }

            //[Display(Name = "FechaFinSustitucion")]
            //public DateTime? FechaFinSustitucion { get; set; }

            //[Display(Name = "FechaRenuncia")]
            //public DateTime? FechaRenuncia { get; set; }

            //[Display(Name = "FechaPaseAPlanta")]
            //public DateTime? FechaPaseAPlanta { get; set; }

            //[Display(Name = "FechaUltimoAscenso")]
            //public DateTime? FechaUltimoAscenso { get; set; }
			#endregion


	}
}
