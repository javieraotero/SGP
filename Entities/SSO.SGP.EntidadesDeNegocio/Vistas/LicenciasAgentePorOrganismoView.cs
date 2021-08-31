using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class LicenciasAgentePorOrganismoView
    {
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Agente")]
			public int? Agente { get; set; }

            [Display(Name = "Nombre")]
            public string Nombre{ get; set; }

            [Display(Name = "FechaDesde")]
			public DateTime FechaDesde { get; set; }

			[Display(Name = "FechaHasta")]
			public DateTime? FechaHasta { get; set; }

			[Display(Name = "Licencia")]
			public int Licencia { get; set; }

            [Display(Name = "DescripcionLicencia")]
            public string DescripcionLicencia { get; set; }

			[Display(Name = "Estado")]
			public string Estado { get; set; }


		#endregion

	}
}
