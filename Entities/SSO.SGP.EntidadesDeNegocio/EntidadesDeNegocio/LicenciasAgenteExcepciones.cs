
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
    [MetadataTypeAttribute(typeof(LicenciasAgenteExcepcionesMetaData))]
    [Table("LicenciasAgenteExcepciones")]
    public partial class LicenciasAgenteExcepciones
    {
        #region Constructor
        public LicenciasAgenteExcepciones()
        {
            // Prueba de codigo
        }
        #endregion

        #region Propiedades

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe ingresar agente")]
        public int Agente { get; set; }

        [Required(ErrorMessage = "Debe ingresar fecha")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Debe ingresar la licencia del agente")]
        public int Licencia { get; set; }

        [Required(ErrorMessage = "Debe ingresar resoluci�n")]
        public string Resolucion { get; set; }

        [Required(ErrorMessage = "Debe ingresar d�as que habilita")]
        public int DiasQueHabilita { get; set; }

        public string Observaciones { get; set; }

        [Required(ErrorMessage = "Debe ingresar usuario")]
        public int UsuarioAlta { get; set; }

        [Required(ErrorMessage = "Debe ingresar fecha de fin")]
        public DateTime FechaFin { get; set; }

        #endregion

    }
}
