using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
    /// <summary>
    /// MetaData Generada por el Generador de codigo.
    /// </summary>
    public partial class CesidaOrganismosRefMetaData
    {
        #region Propiedades

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "CodCaracter")]
        public int? CodCaracter { get; set; }

        [Display(Name = "Caracter")]
        public string Caracter { get; set; }

        [Display(Name = "CodJurisdiccion")]
        public string CodJurisdiccion { get; set; }

        [Display(Name = "Jurisdiccion")]
        public string Jurisdiccion { get; set; }

        [Display(Name = "CodUnidad")]
        public int? CodUnidad { get; set; }

        [Display(Name = "Unidad")]
        public string Unidad { get; set; }
        #endregion


           

    }
}
