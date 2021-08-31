
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SSO.SGP.EntidadesDeNegocio
{

    //[MetadataTypeAttribute(typeof(TurnosWebParametrosMetaData))]
    [Table("ECO_Proveedores")]
    public partial class ECO_Proveedores
    {
        #region Constructor
        public ECO_Proveedores()
        {
            // Prueba de codigo
        }
        #endregion

        #region Propiedades

        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        public string RazonSocial { get; set; }
        public eTiposProveedores TipoProveedor { get; set; }

        [MaxLength(11)]
        public string CUIT { get; set; }
        public int Provincia { get; set; }
        public int Localidad { get; set; }
        [MaxLength(200)]
        public string DomicilioElectronico { get; set; }
        [MaxLength(150)]
        public string DomicilioPostal { get; set; }
        [MaxLength(15)]
        public string TelefonoMovil { get; set; }
        public bool InscriptoLaPampa { get; set; }
        public DateTime FechaAlta { get; set; }

        public int IdUsuario { get; set; }

        [MaxLength(150)]
        public string NombreFantasia { get; set; }

        public string ObservacionesEconomia { get; set; }

        public eEstadosProveedores Estado { get; set; }

        public DateTime? FechaCambioEstado { get; set; }

        [ForeignKey("Provincia")]
        public virtual ProvinciasRef Provincia_ { get; set; }

        [ForeignKey("Localidad")]
        public virtual LocalidadesRef Localidad_ { get; set; }

        #endregion

    }
}
