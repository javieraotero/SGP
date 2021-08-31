
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
	public partial class Usuarios
	{
		#region Constructor
		public Usuarios()
		{
            //this.webpages_Roles = new HashSet<webpages_Roles>();
		}
		#endregion

		#region Propiedades 

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Circunscripcion")]
		public int Circunscripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar ApellidoYNombre")]
		[StringLength(100, ErrorMessage ="ApellidoYNombre no puede superar los 100 caracteres")]
		public string ApellidoYNombre { get; set; }

		[Required(ErrorMessage = "Debe ingresar Usuario")]
		[StringLength(20, ErrorMessage ="Usuario no puede superar los 20 caracteres")]
		public string Usuario { get; set; }

		[Required(ErrorMessage = "Debe ingresar Clave")]
		[StringLength(40, ErrorMessage ="Clave no puede superar los 40 caracteres")]
		public string Clave { get; set; }

		public int? GrupoUsuarioUltimoIngreso { get; set; }

		[StringLength(50, ErrorMessage ="Correo no puede superar los 50 caracteres")]
		public string Correo { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

		public DateTime? FechaCambioClave { get; set; }

		public DateTime? FechaUltimoIngreso { get; set; }

		[StringLength(15, ErrorMessage ="IPUltimoIngreso no puede superar los 15 caracteres")]
		public string IPUltimoIngreso { get; set; }

		[Required(ErrorMessage = "Debe ingresar Estado")]
		public int Estado { get; set; }

		//[Required(ErrorMessage = "Debe ingresar Conectado")]
		public bool Conectado { get; set; }

		[Required(ErrorMessage = "Debe ingresar Persona")]
		public int Persona { get; set; }

		[Required(ErrorMessage = "Debe ingresar Cargo")]
		public int Cargo { get; set; }

		public int? OrganismoUltimoIngreso { get; set; }

		public int? SubAmbito { get; set; }

		[Required(ErrorMessage = "Debe ingresar TieneFirma")]
		public bool TieneFirma { get; set; }

		[Required(ErrorMessage = "Debe ingresar NotificacionElectronica")]
		public bool NotificacionElectronica { get; set; }

		public int? UsuarioAlta { get; set; }

		public int? UsuarioModifica { get; set; }

		public int? UsuarioElimina { get; set; }

		public DateTime? FechaModificacion { get; set; }

		public DateTime? FechaEliminacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar AceptoTerminosCondiciones")]
		public bool AceptoTerminosCondiciones { get; set; }

		public DateTime? FechaTerminosCondiciones { get; set; }

		public DateTime? FechaSuspendidoDesde { get; set; }

		public DateTime? FechaSuspendidoHasta { get; set; }

        public bool EsSubrogante { get; set; }

        public virtual ICollection<webpages_Roles> webpages_Roles { get; set; }

        [ForeignKey("SubAmbito")]
        public virtual Ambitos SubAmbitos { get; set; }
		#endregion

	}
}
