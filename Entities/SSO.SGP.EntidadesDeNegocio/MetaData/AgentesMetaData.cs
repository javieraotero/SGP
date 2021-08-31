using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
    /// <summary>
    /// MetaData Generada por el Generador de codigo.
    /// </summary>
    public partial class AgentesMetaData
    {
        #region Propiedades

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Legajo")]
        public int Legajo { get; set; }

        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        [Display(Name = "Profesion")]
        public string Profesion { get; set; }

        [Display(Name = "Estudios Cursados")]
        public string EstudiosCursados { get; set; }

        [Display(Name = "Nro. Afiliado")]
        public string AfiliadoISS { get; set; }

        [Display(Name = "Fecha de Casamiento")]
        public DateTime? FechaDeCasamiento { get; set; }

        [Display(Name = "Persona")]
        public int Persona { get; set; }

        [Display(Name = "Activo")]
        public bool Activo { get; set; }

        [Display(Name = "FechaBaja")]
        public DateTime? FechaBaja { get; set; }

        [Display(Name = "FechaAlta")]
        public DateTime FechaAlta { get; set; }

        [Display(Name = "Numero PS")]
        public int? NumeroPS { get; set; }

        [Display(Name = "Domicilio")]
        public string Domicilio { get; set; }

        [Display(Name = "Fecha Ultimo Ascenso")]
        public DateTime? FechaUltimoAscenso { get; set; }

        [Display(Name = "Ultimo Cargo")]
        public int? UltimoCargo { get; set; }

        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        [Display(Name = "Celular")]
        public string Celular { get; set; }

        [Display(Name = "Id de Dispositivo")]
        public string Device_Id { get; set; }

        [Display(Name = "Acceso a App")]
        public bool AppActivo { get; set; }

        [Display(Name = "TokenGCM")]
        public string TokenGCM { get; set; }

        [Display(Name = "Bonif. Activa")]
        public bool TieneBonificacion { get; set; }

        [Display(Name = "% Bonif")]
        public decimal? Bonificacion{ get; set; }

        #endregion


    }
}
