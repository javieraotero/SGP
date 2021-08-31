using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSO.SGP.EntidadesDeNegocio
{
    /// <summary>
    /// Vista generada por generador de codigo
    /// </summary>
    [Table("RegistroRebeldiaDTO")]
    public class RegistroRebeldiaDTO
    {
        #region Propiedades

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Registro")]
        public int Registro { get; set; }

        [Display(Name = "Parte")]
        public int Parte { get; set; }

        [Display(Name = "UsuarioAlta")]
        public int UsuarioAlta { get; set; }

        [Display(Name = "FechaAlta")]
        public DateTime FechaAlta { get; set; }

        [Display(Name = "Numero")]
        public int Numero { get; set; }

        [Display(Name = "NumeroIncidente")]
        public int NumeroIncidente { get; set; }

        [Display(Name = "Persona")]
        public string Persona { get; set; }

        [Display(Name = "Estado")]
        public int Estado { get; set; }

        [Display(Name = "EstadoDescripcion")]
        public string EstadoDescripcion { get; set; }

        [Display(Name = "FechaInicio")]
        public DateTime? FechaInicio { get; set; }

        [Display(Name = "TipoRegistroDescripcion")]
        public string TipoRegistroDescripcion { get; set; }

        [Display(Name = "Abreviatura")]
        public string Abreviatura { get; set; }

        [Display(Name = "NumeroCompletoLegajo")]
        public string NumeroCompletoLegajo { get; set; }

        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }

        [Display(Name = "Circunscripcion")]
        public int? Circunscripcion { get; set; }

        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Display(Name = "Nombres")]
        public string Nombres { get; set; }

        [Display(Name = "Alias")]
        public string Alias { get; set; }

        [Display(Name = "TipoDocumentoDescripcion")]
        public string TipoDocumentoDescripcion { get; set; }

        [Display(Name = "NroDocumento")]
        public long? NroDocumento { get; set; }

        [Display(Name = "FechaNacimiento")]
        public DateTime? FechaNacimiento { get; set; }

        [Display(Name = "Nacionalidad")]
        public string Nacionalidad { get; set; }

        #endregion


    }
}
