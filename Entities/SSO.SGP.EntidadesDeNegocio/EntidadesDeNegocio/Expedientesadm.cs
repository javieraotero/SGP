
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
	[MetadataTypeAttribute(typeof(ExpedientesadmMetaData))]
	[Table("Expedientesadm")]
	public partial class Expedientesadm
	{
		#region Constructor
		public Expedientesadm()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Tipo")]
		public int Tipo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Categoria")]
		public int Categoria { get; set; }

		[Required(ErrorMessage = "Debe ingresar Numero")]
		public string Numero { get; set; }

		public int? NumeroDeTramite { get; set; }

		public int? NumeroDeCorresponde { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaDeAlta")]
		public DateTime FechaDeAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fecha")]
		public DateTime Fecha { get; set; }

		public int? UsuarioAlta { get; set; }

		public int? UsuarioBaja { get; set; }

		public DateTime? FechaDeBaja { get; set; }

		[StringLength(600, ErrorMessage ="Caratula no puede superar los 600 caracteres")]
		public string Caratula { get; set; }

		public int? OrganismoIniciador { get; set; }

		[StringLength(80, ErrorMessage ="TextoIniciador no puede superar los 80 caracteres")]
		public string TextoIniciador { get; set; }

		public int? ExpedienteAcumulado { get; set; }

		public DateTime? FechaAcumulado { get; set; }

		public int? UsuarioAcumulado { get; set; }

		public int? ExpedientePadre { get; set; }

		[Required(ErrorMessage = "Debe ingresar UltimoCorresponde")]
		public int UltimoCorresponde { get; set; }

		public bool Archivado { get; set; }

		public DateTime? FechaArchivado { get; set; }

		public int? UsuarioArchiva { get; set; }

		public int? AnioContable { get; set; }

        public int? Ambito { get; set; }

        public int? Destino { get; set; }

		public virtual ICollection<Actuacionesadm> Actuacionesadm { get; set; }

		[ForeignKey("Tipo")]
		public virtual TiposExpedienteadmRef Tipos { get; set; }

		[ForeignKey("Categoria")]
		public virtual CategoriasExpedienteadmRef Categorias { get; set; }

		//[ForeignKey("UsuarioAlta")]
		//public virtual Usuarios UsuarioAltas { get; set; }

		//[ForeignKey("UsuarioBaja")]
		//public virtual Usuarios UsuarioBajas { get; set; }

		[ForeignKey("OrganismoIniciador")]
		public virtual OrganismosRef OrganismoIniciadors { get; set; }

		//public virtual ICollection<Expedientesadm> Expedientesadm3 { get; set; }

		//[ForeignKey("UsuarioAcumulado")]
		//public virtual Usuarios UsuarioAcumulados { get; set; }

        [ForeignKey("Ambito")]
        public virtual Ambitos Ambitos { get; set; }

		//public virtual ICollection<Expedientesadm> Expedientesadm1 { get; set; }

		//[ForeignKey("UsuarioArchiva")]
		//public virtual Usuarios UsuarioArchivas { get; set; }

        public virtual ICollection<Facturas> Facturas { get; set; }
        #endregion

    }
}
