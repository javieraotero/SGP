using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
    /// <summary>
    /// Vista generada por generador de codigo
    /// </summary>
    public class DiasDeLicenciaView
    {
        #region Propiedades

        [Display(Name = "Licencia")]
        public string Licencia { get; set; }

        [Display(Name = "Días")]
        public int Dias { get; set; }

        #endregion
    }

    public class AgentesConBonificacionView
    {
        #region Propiedades

        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Legajo")]
        public int Legajo { get; set; }

        [Display(Name = "Cargo")]
        public string Cargo { get; set; }

        [Display(Name = "Organismo")]
        public string Organismo { get; set; }

        [Display(Name = "Dias")]
        public int Dias { get; set; }

        [Display(Name = "Porcentaje")]
        public decimal Porcentaje { get; set; }

        [Display(Name = "Agente")]
        public int Agente { get; set; }

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "IdCargo")]
        public int IdCargo { get; set; }

        [Display(Name = "IdOrganismo")]
        public int IdOrganismo { get; set; }

        #endregion
    }

    public class AgentesConBonificacionExcelView
    {
        #region Propiedades

        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Legajo")]
        public int Legajo { get; set; }

        [Display(Name = "Cargo")]
        public string Cargo { get; set; }

        [Display(Name = "Organismo")]
        public string Organismo { get; set; }

        [Display(Name = "Porcentaje")]
        public decimal Porcentaje { get; set; }

        [Display(Name = "Lic.")]
        public int Dias { get; set; }

        [Display(Name = "Liquidar")]
        public int Liquidar { get; set; }        

        #endregion
    }
}
