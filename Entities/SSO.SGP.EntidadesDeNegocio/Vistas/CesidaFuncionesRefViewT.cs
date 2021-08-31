using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class CesidaFuncionesRefViewT
	{
        #region Propiedades

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "NroConvenio")]
        public int? NroConvenio { get; set; }

        [Display(Name = "NroFuncion")]
        public int? NroFuncion { get; set; }

        [Display(Name = "Funcion")]
        public string Funcion { get; set; }
        #endregion


    }
}
