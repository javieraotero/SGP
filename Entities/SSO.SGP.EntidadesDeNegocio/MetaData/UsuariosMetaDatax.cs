using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
    /// <summary>
    /// MetaData Generada por el Generador de codigo.
    /// </summary>
    public partial class UsuariosMetaDatax
    {
        #region Propiedades

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Nombre y Apellido")]
        public string NombrePersona { get; set; }

        [Display(Name = "Nombre de Usuario")]
        public string NombreUsuario { get; set; }

        [Display(Name = "Domicilio")]
        public string Domicilio { get; set; }

        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        [Display(Name = "Celular")]
        public string Celular { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "El formato del email no es valido.")]
        public string Email { get; set; }

        [Display(Name = "FechaAlta")]
        public DateTime FechaAlta { get; set; }

        [Display(Name = "FechaBaja")]
        public DateTime? FechaBaja { get; set; }

        [Display(Name = "Activo")]
        public bool Activo { get; set; }
        #endregion


    }
}
