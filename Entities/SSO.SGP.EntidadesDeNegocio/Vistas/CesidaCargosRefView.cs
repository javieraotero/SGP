using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class CesidaCargosRefView
	{
        #region Propiedades

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "NroConvenio")]
        public int? NroConvenio { get; set; }

        [Display(Name = "Convenio")]
        public string Convenio { get; set; }

        [Display(Name = "NroRama")]
        public int? NroRama { get; set; }

        [Display(Name = "Rama")]
        public string Rama { get; set; }

        [Display(Name = "NroCategoria")]
        public int? NroCategoria { get; set; }

        [Display(Name = "Categoria")]
        public string Categoria { get; set; }
        #endregion


    }
}
