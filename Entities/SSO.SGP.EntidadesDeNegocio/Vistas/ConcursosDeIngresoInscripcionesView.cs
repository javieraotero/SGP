using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
    /// <summary>
    /// Vista generada por generador de codigo
    /// </summary>
    public class ConcursosDeIngresoInscripcionesView
    {
        #region Propiedades

        [Display(Name = "Id", Order = 0)]
        public int Id { get; set; }

        [Display(Name = "Feecha", Order = 10)]
        public DateTime FechaPreinscripcion { get; set; }

        [Display(Name = "Apellido", Order = 15)]
        public string Apellido { get; set; }

        [Display(Name = "Nombres", Order = 20)]
        public string Nombres { get; set; }

        [Display(Name = "DNI", Order = 10)]
        public long DNI { get; set; }

        [Display(Name = "Ciudad", Order = 15)]
        public string Ciudad { get; set; }

        [Display(Name = "Provincia", Order = 15)]
        public string Provincia { get; set; }

        [Display(Name = "Recibido?", Order = 5)]
        public string Recibido { get; set; }

        #endregion
    }
}
