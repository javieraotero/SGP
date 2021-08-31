using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
    /// <summary>
    /// MetaData Generada por el Generador de codigo.
    /// </summary>
    public partial class LicenciasAgenteMetaData
    {
        #region Propiedades

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Agente")]
        public int? Agente { get; set; }

        [Display(Name = "Desde")]
        public DateTime FechaDesde { get; set; }

        [Display(Name = "Hasta")]
        public DateTime? FechaHasta { get; set; }

        [Display(Name = "Seleccione Licencia")]
        public int Licencia { get; set; }

        [Display(Name = "Subrogante")]
        public int? Subrogante { get; set; }

        [Display(Name = "Activa")]
        public bool Activa { get; set; }

        [Display(Name = "FechaAlta")]
        public DateTime? FechaAlta { get; set; }

        [Display(Name = "UsuarioAlta")]
        public int? UsuarioAlta { get; set; }

        [Display(Name = "FechaModificacion")]
        public DateTime? FechaModificacion { get; set; }

        [Display(Name = "UsuarioModifica")]
        public int? UsuarioModifica { get; set; }

        [Display(Name = "FechaEliminacion")]
        public DateTime? FechaEliminacion { get; set; }

        [Display(Name = "UsuarioElimina")]
        public int? UsuarioElimina { get; set; }

        [Display(Name = "Seleccione Agente")]
        public int? AgenteRRHH { get; set; }

        [Display(Name = "Observaciones")]
        public string Observaciones { get; set; }

        [Display(Name = "Solicitada por App")]
        public bool SolicitadaPorApp { get; set; }

        [Display(Name = "Token")]
        public string Token { get; set; }
        #endregion


    }
}
