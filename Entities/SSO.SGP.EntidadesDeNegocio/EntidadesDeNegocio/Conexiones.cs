
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
	[MetadataTypeAttribute(typeof(ConexionesMetaData))]
	[Table("Conexiones")]
	public partial class Conexiones
	{
		#region Constructor
		public Conexiones()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Causa")]
		public int Causa { get; set; }

		[Required(ErrorMessage = "Debe ingresar Persona")]
		public int Persona { get; set; }

		[StringLength(250, ErrorMessage ="DomicilioReal no puede superar los 250 caracteres")]
		public string DomicilioReal { get; set; }

		public int? Localidad { get; set; }

		[StringLength(250, ErrorMessage ="DomicilioConstituido no puede superar los 250 caracteres")]
		public string DomicilioConstituido { get; set; }

		public int? Apoderado { get; set; }

		public int? Provincia { get; set; }

		[StringLength(50, ErrorMessage ="LocalidadResidual no puede superar los 50 caracteres")]
		public string LocalidadResidual { get; set; }

		public int? Orden { get; set; }

		[Required(ErrorMessage = "Debe ingresar Rol")]
		public int Rol { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activo")]
		public bool Activo { get; set; }

		public virtual ICollection<ActuacionesCivilNotificacion> ActuacionesCivilNotificacion { get; set; }

		public virtual ICollection<AudienciasNotificacionCivil> AudienciasNotificacionCivil { get; set; }

		[ForeignKey("Causa")]
		public virtual Causas Causas { get; set; }

		[ForeignKey("Persona")]
		public virtual Personas Personas { get; set; }

		[ForeignKey("Localidad")]
		public virtual LocalidadesRef Localidads { get; set; }

		[ForeignKey("Apoderado")]
		public virtual Usuarios Apoderados { get; set; }

		[ForeignKey("Provincia")]
		public virtual ProvinciasRef Provincias { get; set; }

		[ForeignKey("Rol")]
		public virtual RolesPersonaCivilRef Rols { get; set; }
		#endregion

	}
}
