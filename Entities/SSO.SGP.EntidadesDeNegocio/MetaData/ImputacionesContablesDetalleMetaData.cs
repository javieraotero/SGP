using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
    /// <summary>
    /// MetaData Generada por el Generador de codigo.
    /// </summary>
    public partial class ImputacionesContablesDetalleMetaData
    {
        #region Propiedades

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "ImputacionContable")]
        public int ImputacionContable { get; set; }

        [Display(Name = "Año Contable")]
        public int AnioContable { get; set; }

        [Display(Name = "Partida")]
        public int Partida { get; set; }

        [Display(Name = "Division")]
        public int Division { get; set; }

        [Display(Name = "Importe")]
        public decimal Importe { get; set; }

        [Display(Name = "Usuario")]
        public int Usuario { get; set; }

        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }

        [Display(Name = "FechaElimina")]
        public DateTime? FechaElimina { get; set; }

        [Display(Name = "UsuarioElimina")]
        public int? UsuarioElimina { get; set; }
        #endregion


    }
}
