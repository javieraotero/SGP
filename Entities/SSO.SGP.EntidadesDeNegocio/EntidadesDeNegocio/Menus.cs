
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
    [MetadataTypeAttribute(typeof(MenusMetaData))]
    public partial class Menus
    {
        #region Constructor
        public Menus()
        {
            // Prueba de codigo
            this.webpages_Roles = new HashSet<webpages_Roles>();
        }
        #endregion

        #region Propiedades

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe ingresar Label")]
        [StringLength(50, ErrorMessage = "Label no puede superar los 50 caracteres")]
        public string Label { get; set; }

        [StringLength(50, ErrorMessage = "Accion no puede superar los 50 caracteres")]
        public string Accion { get; set; }

        [StringLength(50, ErrorMessage = "Controlador no puede superar los 50 caracteres")]
        public string Controlador { get; set; }

        public int? Padre { get; set; }

        [StringLength(20, ErrorMessage = "IconClass no puede superar los 20 caracteres")]
        public string IconClass { get; set; }

        [StringLength(250, ErrorMessage = "ToolTip no puede superar los 250 caracteres")]
        public string ToolTip { get; set; }

        public int? Orden { get; set; }

        public int? TabIndex { get; set; }

        [StringLength(500, ErrorMessage = "Tabs no puede superar los 500 caracteres")]
        public string Tabs { get; set; }

        [StringLength(25, ErrorMessage = "TituloDePagina no puede superar los 25 caracteres")]
        public string TituloDePagina { get; set; }

        [StringLength(50, ErrorMessage = "Descripcion no puede superar los 50 caracteres")]
        public string Descripcion { get; set; }

        public virtual ICollection<Menus> MenusMenu { get; set; }

        public virtual ICollection<webpages_Roles> webpages_Roles { get; set; }

        [ForeignKey("Padre")]
        public virtual Menus MenuPadre { get; set; }

        public string Area { get; set; }

        #endregion

    }
}
