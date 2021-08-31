using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
    /// <summary>
    /// Vista generada por generador de codigo
    /// </summary>
    public class TurnosWebView
    {
        #region Propiedades

        [Display(Name = "Id" ,Order =0)]
        public int Id { get; set; }

        [Display(Name = "Tipo", Order = 15)]
        public string Tipo { get; set; }

        [Display(Name = "Nombre",Order =15)]
        public string Nombre { get; set; }

        [Display(Name = "DNI", Order = 7)]
        public long  DNI { get; set; }

        [Display(Name = "Teléfono", Order =7)]
        public string Telefono { get; set; }

        [Display(Name = "Fecha", Order =7)]
        public DateTime Fecha { get; set; }

        [Display(Name = "Hora", Order =5)]
        public TimeSpan Hora { get; set; }

        [Display(Name = "Abogado", Order = 5)]
        public string Abogado { get; set; }

        [Display(Name = "Perito", Order =5)]
        public string Perido { get; set; }

        //[Display(Name = "Expedientes", Order =10)]
        //public string Expedientes { get; set; }

        [Display(Name = "Contactar", Order = 5)]
        public string Contactar { get; set; }
        [Display(Name = "Urgente", Order =5)]
        public string Urgente { get; set; }
        [Display(Name = "Comentarios", Order = 20)]
        public string Comentarios { get; set; }
        [Display(Name = "Estado", Order = 5)]
        public string Estado { get; set; }

        [Display(Name = "op", Order = 5)]
        public string operacion { get; set; }



        #endregion


    }
}
