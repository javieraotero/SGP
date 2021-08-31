using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class CesidaMovimientoAgentesViewT
	{
        #region Propiedades

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Agente")]
        public int Agente { get; set; }

        [Display(Name = "Movimiento")]
        public int Movimiento { get; set; }

        [Display(Name = "UsuarioAlta")]
        public int UsuarioAlta { get; set; }

        [Display(Name = "FechaAlta")]
        public DateTime FechaAlta { get; set; }

        [Display(Name = "Autorizado")]
        public bool Autorizado { get; set; }

        [Display(Name = "MensajeRespuesta")]
        public string MensajeRespuesta { get; set; }

        [Display(Name = "NroLote")]
        public int? NroLote { get; set; }

        [Display(Name = "CodOperacion")]
        public int? CodOperacion { get; set; }

        [Display(Name = "Persona")]
        public int? Persona { get; set; }

        [Display(Name = "FechaEnvio")]
        public DateTime? FechaEnvio { get; set; }

        [Display(Name = "FechaAutoriza")]
        public DateTime? FechaAutoriza { get; set; }

        [Display(Name = "UsuarioAutoriza")]
        public int? UsuarioAutoriza { get; set; }
        #endregion


    }
}
