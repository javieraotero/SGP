using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
    /// <summary>
    /// Vista generada por generador de codigo
    /// </summary>
    public class DivisionesExtraPresupuestariasViewT
    {
        #region Propiedades

        [Display(Name = "Id", AutoGenerateField = false)]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Cod. CESIDA")]
        public string CodigoCESIDA { get; set; }

        [Display(Name = "Partida")]
        public string PartidaPresupuestaria { get; set; }

        #endregion

    }



}
