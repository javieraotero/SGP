
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
	[MetadataTypeAttribute(typeof(ExpedientesPersonaadmMetaData))]
	[Table("ExpedientesPersonaadm")]
	public partial class ExpedientesPersonaadm
	{
		#region Constructor
		public ExpedientesPersonaadm()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Expediente")]
		public int Expediente { get; set; }

		[Required(ErrorMessage = "Debe ingresar Persona")]
		public int Persona { get; set; }

		[Required(ErrorMessage = "Debe ingresar Rol")]
		public int Rol { get; set; }

		[StringLength(100, ErrorMessage ="DomicilioReal no puede superar los 100 caracteres")]
		public string DomicilioReal { get; set; }

		public int? LocalidadReal { get; set; }

		[StringLength(100, ErrorMessage ="Correo no puede superar los 100 caracteres")]
		public string Correo { get; set; }

		[StringLength(255, ErrorMessage ="Observaciones no puede superar los 255 caracteres")]
		public string Observaciones { get; set; }

		[StringLength(100, ErrorMessage ="DomicilioRepresentanteLegal no puede superar los 100 caracteres")]
		public string DomicilioRepresentanteLegal { get; set; }

		[StringLength(50, ErrorMessage ="NombreRepresentanteLegal no puede superar los 50 caracteres")]
		public string NombreRepresentanteLegal { get; set; }

		public int? LocalidadRepsentanteLegal { get; set; }

		[StringLength(100, ErrorMessage ="CorreoRepresentanteLegal no puede superar los 100 caracteres")]
		public string CorreoRepresentanteLegal { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioAlta")]
		public int UsuarioAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

		public int? UsuarioModifica { get; set; }

		public DateTime? FechaModificacion { get; set; }

		[ForeignKey("Expediente")]
		public virtual Expedientesadm Expedientes { get; set; }

		[ForeignKey("Persona")]
		public virtual Personas Personas { get; set; }

		[ForeignKey("Rol")]
		public virtual RolesPersonaadmRef Rols { get; set; }

		[ForeignKey("LocalidadReal")]
		public virtual LocalidadesRef LocalidadReals { get; set; }

		[ForeignKey("LocalidadRepsentanteLegal")]
		public virtual LocalidadesRef LocalidadRepsentanteLegals { get; set; }

		[ForeignKey("UsuarioAlta")]
		public virtual Usuarios UsuarioAltas { get; set; }
		#endregion

	}
}
