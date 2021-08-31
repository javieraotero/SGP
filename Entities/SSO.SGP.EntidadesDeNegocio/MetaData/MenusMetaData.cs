using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
    /// <summary>
    /// MetaData Generada por el Generador de codigo.
    /// </summary>
    public partial class MenusMetaData
    {
        #region Propiedades

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Label")]
        public string Label { get; set; }

        [Display(Name = "Accion")]
        public string Accion { get; set; }

        [Display(Name = "Controlador")]
        public string Controlador { get; set; }

        [Display(Name = "Padre")]
        public int? Padre { get; set; }

        [Display(Name = "IconClass")]
        public string IconClass { get; set; }

        [Display(Name = "ToolTip")]
        public string ToolTip { get; set; }

        [Display(Name = "Orden")]
        public int? Orden { get; set; }

        [Display(Name = "TabIndex")]
        public int? TabIndex { get; set; }

        [Display(Name = "Tabs")]
        public string Tabs { get; set; }

        [Display(Name = "TituloDePagina")]
        public string TituloDePagina { get; set; }

        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
        #endregion


    }
}
