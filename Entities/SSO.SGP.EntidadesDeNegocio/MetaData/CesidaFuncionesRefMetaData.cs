using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
    /// <summary>
    /// MetaData Generada por el Generador de codigo.
    /// </summary>
    public partial class CesidaFuncionesRefMetaData
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
