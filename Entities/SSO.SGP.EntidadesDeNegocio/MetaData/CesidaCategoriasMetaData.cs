using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
    /// <summary>
    /// MetaData Generada por el Generador de codigo.
    /// </summary>
    public partial class CesidaCategoriasMetaData
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
