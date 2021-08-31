using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class AgentesBonificacionesView
	{
        #region Propiedades

        [Display(Name = "Id", Order =0)]
        public int Id { get; set; }

        [Display(Name = "Agente", Order = 20)]
        public string Agente { get; set; }

        [Display(Name = "Bonificación", Order = 10)]
        public decimal Porcentaje { get; set; }

        [Display(Name = "Aplica", Order = 10)]
        public bool Aplica { get; set; }

        [Display(Name = "Cargo", Order = 15)]
        public string Cargo { get; set; }

        [Display(Name = "Organismo", Order = 15)]
        public string Organismo { get; set; }

        [Display(Name = "Mes", Order = 5)]
        public int Mes { get; set; }

        [Display(Name = "Anio", Order = 5)]
        public int Anio { get; set; }

        [Display(Name = "Licencias", Order = 5)]
        public int DiasDeLicencia { get; set; }

        [Display(Name = "Autorizados", Order = 5)]
        public int Autorizados{ get; set; }


        #endregion


    }
}
