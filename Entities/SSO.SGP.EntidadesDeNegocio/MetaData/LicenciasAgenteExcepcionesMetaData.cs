using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class LicenciasAgenteExcepcionesMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Agente")]
			public int Agente { get; set; }

			[Display(Name = "Fecha")]
			public DateTime Fecha { get; set; }

            [Display(Name = "LicenciaAgente")]
			public int Licencia { get; set; }

            [Display(Name = "Resolucion")]
            public string Resolucion { get; set; }

            [Display(Name = "DiasQueHabilita")]
            public int DiasQueHabilita { get; set; }

            [Display(Name = "Observaciones")]
            public string Observaciones { get; set; }

            [Display(Name = "UsuarioAlta")]
			public int UsuarioAlta{ get; set; }

			#endregion


	}
}
