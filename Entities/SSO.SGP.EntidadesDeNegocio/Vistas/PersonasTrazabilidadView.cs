using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
    /// <summary>
    /// Vista generada por generador de codigo
    /// </summary>
    public class PersonasTrazabilidadView
    {
        #region Propiedades

        [Display(Name = "Id" ,Order =0)]
        public int Id { get; set; }

        [Display(Name = "DNI", Order = 10)]
        public long? DNI { get; set; }

        [Display(Name = "Nombre",Order =40)]
        public string Nombre { get; set; }       

        [Display(Name = "Teléfono", Order =20)]
        public string Telefono { get; set; }

        [Display(Name = "Día", Order =15)]
        public DateTime Fecha { get; set; }

        [Display(Name = "Hora", Order = 15)]
        public TimeSpan Hora { get; set; }

        #endregion


    }

    public class PersonasTrazabilidadDetalleView
    {
        #region Propiedades

        [Display(Name = "Id", Order = 0)]
        public int Id { get; set; }

        [Display(Name = "DNI", Order = 7)]
        public long? DNI { get; set; }

        [Display(Name = "Nombre", Order = 25)]
        public string Nombre { get; set; }

        [Display(Name = "Organismo", Order = 30)]
        public string Organismo { get; set; }

        [Display(Name = "Teléfono", Order = 10)]
        public string Telefono { get; set; }

        [Display(Name = "Día", Order = 10)]
        public DateTime Fecha { get; set; }

        [Display(Name = "Hora", Order = 10)]
        public TimeSpan Hora { get; set; }

        #endregion


    }

}
