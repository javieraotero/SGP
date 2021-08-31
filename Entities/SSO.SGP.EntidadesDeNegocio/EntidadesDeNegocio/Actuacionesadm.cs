
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
	[MetadataTypeAttribute(typeof(ActuacionesadmMetaData))]
	[Table("Actuacionesadm")]
	public partial class Actuacionesadm
	{
		#region Constructor
		public Actuacionesadm()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Expediente")]
		public int Expediente { get; set; }

		[StringLength(600, ErrorMessage ="Descripcion no puede superar los 600 caracteres")]
		public string Descripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fecha")]
		public DateTime Fecha { get; set; }

		public int? UsuarioAlta { get; set; }

		[StringLength(500, ErrorMessage ="Observaciones no puede superar los 500 caracteres")]
		public string Observaciones { get; set; }

		public DateTime? FechaRecepcion { get; set; }

		public int? UsuarioRecepcion { get; set; }

		public int? OficinaOrigen { get; set; }

		public int? SubAmbitoOrigen { get; set; }

		[Required(ErrorMessage = "Debe ingresar Anulado")]
		public bool Anulado { get; set; }

		public DateTime? FechaAnulado { get; set; }

		public int? UsuarioAnulacion { get; set; }

		[StringLength(255, ErrorMessage ="MotivoAnulacion no puede superar los 255 caracteres")]
		public string MotivoAnulacion { get; set; }

		[StringLength(2147483647, ErrorMessage ="Texto no puede superar los 2147483647 caracteres")]
		public string Texto { get; set; }

		public DateTime? FechaPublicacion { get; set; }

		public int? UsuarioPublica { get; set; }

		public DateTime? FechaUltimaModificacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar TipoActuacion")]
		public int TipoActuacion { get; set; }

		public int? ModeloAplicado { get; set; }

		public int? Firmante1 { get; set; }

		public DateTime? FechaFirmante1 { get; set; }

		public int? Firmante2 { get; set; }

		public DateTime? FechaFirmante2 { get; set; }

		public int? Firmante3 { get; set; }

		public DateTime? FechaFirmante3 { get; set; }

		public int? Firmante4 { get; set; }

		public DateTime? FechaFirmante4 { get; set; }

		public int? Firmante5 { get; set; }

		public DateTime? FechaFirmante5 { get; set; }

		public bool RequiereCargo { get; set; }

		public int? SubAmbitoCargo { get; set; }

		public DateTime? FechaCargo { get; set; }

		public int? UsuarioCargo { get; set; }

		public int? Fojas { get; set; }

        public int? OrganismoCargo { get; set; }

		public virtual ICollection<ExpedientesDocumentoadm> ExpedientesDocumentoadm { get; set; }

		public virtual ICollection<ExpedientesPaseadm> ExpedientesPaseadm { get; set; }

		[ForeignKey("Expediente")]
		public virtual Expedientesadm Expedientes { get; set; }

		//[ForeignKey("UsuarioAlta")]
		//public virtual Usuarios UsuarioAltas { get; set; }

		//[ForeignKey("UsuarioRecepcion")]
		//public virtual Usuarios UsuarioRecepcions { get; set; }

		[ForeignKey("OficinaOrigen")]
		public virtual OrganismosRef OficinaOrigens { get; set; }

		[ForeignKey("SubAmbitoOrigen")]
		public virtual Ambitos SubAmbitoOrigens { get; set; }

		//[ForeignKey("UsuarioAnulacion")]
		//public virtual Usuarios UsuarioAnulacions { get; set; }

		//[ForeignKey("UsuarioPublica")]
		//public virtual Usuarios UsuarioPublicas { get; set; }

		[ForeignKey("TipoActuacion")]
		public virtual TiposActuacionadmRef TipoActuacions { get; set; }

		[ForeignKey("ModeloAplicado")]
		public virtual ModelosEscrito ModeloAplicados { get; set; }

		//[ForeignKey("Firmante1")]
		//public virtual Usuarios Firmante1s { get; set; }

		//[ForeignKey("Firmante2")]
		//public virtual Usuarios Firmante2s { get; set; }

		//[ForeignKey("Firmante3")]
		//public virtual Usuarios Firmante3s { get; set; }

		//[ForeignKey("Firmante4")]
		//public virtual Usuarios Firmante4s { get; set; }

		//[ForeignKey("Firmante5")]
		//public virtual Usuarios Firmante5s { get; set; }

		[ForeignKey("SubAmbitoCargo")]
		public virtual Ambitos SubAmbitoCargos { get; set; }

        //[ForeignKey("UsuarioCargo")]
        //public virtual Usuarios UsuarioCargos { get; set; }
        #endregion

    }
}
