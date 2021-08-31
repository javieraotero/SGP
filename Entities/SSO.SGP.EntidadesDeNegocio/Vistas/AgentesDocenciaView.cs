using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
    /// <summary>
    /// Vista generada por generador de codigo
    /// </summary>
    public class AgentesDocenciaView
    {
        #region Propiedades

        [Display(Name = "Id", Order = 0)]
        public int Id { get; set; }

        [Display(Name = "Fecha", Order = 10)]
        public DateTime Fecha { get; set; }

        [Display(Name = "Institucion", Order = 20)]
        public string Institucion { get; set; }

        [Display(Name = "CargaHoraria", Order = 7)]
        public int CargaHoraria { get; set; }

        [Display(Name = "HorasCatedra", Order = 10)]
        public bool HorasCatedra { get; set; }

        [Display(Name = "HorasSemanales", Order = 10)]
        public bool HorasSemanales { get; set; }

        [Display(Name = "Observaciones", Order = 30)]
        public string Observaciones { get; set; }

        #endregion


    }
}
