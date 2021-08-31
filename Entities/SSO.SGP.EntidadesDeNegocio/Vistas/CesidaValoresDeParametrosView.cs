using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class CesidaValoresDeParametrosView
	{
        #region Propiedades

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Parametro")]
        public int? Parametro { get; set; }

        [Display(Name = "Valor")]
        public string Valor { get; set; }
        #endregion


    }
}
