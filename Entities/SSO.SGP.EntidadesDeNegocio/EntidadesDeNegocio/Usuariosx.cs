
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SSO.SGP.MetaData;


namespace SSO.SGP.EntidadesDeNegocio
{
    /// <summary>
    /// Entidad Generada por el Generador de codigo.
    /// </summary>
    [MetadataTypeAttribute(typeof(UsuariosMetaData))]
    public partial class Usuariosx
    {
        #region Constructor
        public Usuariosx()
        {
            // Prueba de codigo
            this.webpages_Roles = new HashSet<webpages_Roles>();
        }
        #endregion

        #region Propiedades

        [Key]
        public int Id { get; set; }

        [StringLength(200, ErrorMessage = "El nombre no puede superar los 200 caracteres")]
        [Required(ErrorMessage = "Debe ingresar su Nombre y Apellido")]
        public string ApellidoYNombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Nombre de Usuario")]
        [StringLength(20, ErrorMessage = "La contraseña no puede superar los 20 caracteres")]
        public string Usuario { get; set; }

        //[StringLength(200, ErrorMessage = "Domicilio no puede superar los 200 caracteres")]
        //public string Domicilio { get; set; }

        //[StringLength(15, ErrorMessage = "Telefono no puede superar los 15 caracteres")]
        //public string Telefono { get; set; }

        //[StringLength(15, ErrorMessage = "Celular no puede superar los 15 caracteres")]
        //public string Celular { get; set; }

        [StringLength(200, ErrorMessage = "Email no puede superar los 200 caracteres")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Debe ingresar FechaAlta")]
        public DateTime FechaAlta { get; set; }

        public DateTime? FechaBaja { get; set; }



        //[Required(ErrorMessage = "Debe ingresar Activo")]
        //public bool Activo { get; set; }

        public virtual ICollection<webpages_Roles> webpages_Roles { get; set; }
        #endregion

    }
}
