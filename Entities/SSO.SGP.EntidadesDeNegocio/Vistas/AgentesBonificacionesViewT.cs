using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class AgentesBonificacionesViewT
	{
        #region Propiedades

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Agente")]
        public int Agente { get; set; }

        [Display(Name = "FechaAlta")]
        public DateTime FechaAlta { get; set; }

        [Display(Name = "Porcentaje")]
        public decimal Porcentaje { get; set; }

        [Display(Name = "Aprobado")]
        public bool Aprobado { get; set; }

        [Display(Name = "Cargo")]
        public int Cargo { get; set; }

        [Display(Name = "Organismo")]
        public int Organismo { get; set; }

        [Display(Name = "Mes")]
        public int Mes { get; set; }

        [Display(Name = "Anio")]
        public int Anio { get; set; }

        [Display(Name = "DiasDeLicencia")]
        public int DiasDeLicencia { get; set; }

        [Display(Name = "FechaDesde")]
        public DateTime? FechaDesde { get; set; }

        [Display(Name = "FechaHasta")]
        public DateTime? FechaHasta { get; set; }
        #endregion


    }
}
