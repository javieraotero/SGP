using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
    public class ResumenLicenciasPorOrganismoViewT
	{
			#region Propiedades

                [Display(Name = "Agente")]
                public String Agente { get; set; }

			    [Display(Name = "Ordinaria")]
			    public int Ordinaria { get; set; }

			    [Display(Name = "Particulares")]
			    public int Particulares { get; set; }

			#endregion


	}
}
