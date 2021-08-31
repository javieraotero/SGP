using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class CesidaCategoriasView
	{
        #region Propiedades

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "NRO_CONVENIO")]
        public int? NRO_CONVENIO { get; set; }

        [Display(Name = "NRO_RAMA")]
        public int? NRO_RAMA { get; set; }

        [Display(Name = "NRO_CATEGORIA")]
        public int? NRO_CATEGORIA { get; set; }

        [Display(Name = "DESCRIPCION")]
        public string DESCRIPCION { get; set; }
        #endregion


    }
}
