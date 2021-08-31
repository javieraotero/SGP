
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
    [MetadataTypeAttribute(typeof(ColaDeMovimientoscesidaMetaData))]
    [Table("ColaDeMovimientosCESIDA")]
    public partial class ColaDeMovimientoscesida
    {
        #region Constructor
        public ColaDeMovimientoscesida()
        {
            // Prueba de codigo
        }
        #endregion

        #region Propiedades

        [Key]
        public int Id { get; set; }

        public int? Nombramiento { get; set; }

        public int? Agente { get; set; }

        [Required(ErrorMessage = "Debe ingresar Movimiento")]
        public int Movimiento { get; set; }

        [Required(ErrorMessage = "Debe ingresar Fecha")]
        public DateTime Fecha { get; set; }

        public DateTime? FechaEnvio { get; set; }

        public int? IdRespuesta { get; set; }

        public string MensajeRespuesta { get; set; }

        [Required(ErrorMessage = "Debe ingresar Intentos")]
        public int Intentos { get; set; }

        public int? Licencia { get; set; }

        public int? IdRegistro { get; set; }

        public DateTime? FechaDesde { get; set; }

        public DateTime? FechaHasta { get; set; }

        public int? Cargo { get; set; }

        public int? Organismo { get; set; }

        public int? Nro_Convenio { get; set; }

        public int? Nro_Rama { get; set; }

        public int? Jornada { get; set; }

        public int? Nro_Unidad_Org { get; set; }

        public int? Nro_Categoria { get; set; }

        public int? Nro_Ubicacion { get; set; }

        public DateTime? Fecha_Aprobacion { get; set; }

        public DateTime? Fecha_Vigencia_Desde { get; set; }

        public string Codigo_Planta { get; set; }

        public string Codigo_Jurisdiccion { get; set; }

        public int? Cantidad_Horas { get; set; }

        public int? NroLote { get; set; }

        public string CodOperacion { get; set; }

        public int? Id_Persona { get; set; }

        public string Cod_Titulo { get; set; }

        public int? Id_Designacion { get; set; }

        public string Situacion_De_Revista { get; set; }

        [ForeignKey("Movimiento")]
		public virtual Movimientoscesida Movimientos { get; set; }
		#endregion

	}
}
