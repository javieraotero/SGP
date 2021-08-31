using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class UsuariosMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Circunscripcion")]
			public int Circunscripcion { get; set; }

			[Display(Name = "Apellido y Nombre")]
			public string ApellidoYNombre { get; set; }

			[Display(Name = "Usuario")]
			public string Usuario { get; set; }

			[Display(Name = "Clave")]
			public string Clave { get; set; }

			[Display(Name = "Grupo Usuario Ultimo Ingreso")]
			public int? GrupoUsuarioUltimoIngreso { get; set; }

			[Display(Name = "Correo")]
			public string Correo { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime FechaAlta { get; set; }

			[Display(Name = "FechaCambioClave")]
			public DateTime? FechaCambioClave { get; set; }

			[Display(Name = "FechaUltimoIngreso")]
			public DateTime? FechaUltimoIngreso { get; set; }

			[Display(Name = "IPUltimoIngreso")]
			public string IPUltimoIngreso { get; set; }

			[Display(Name = "Estado")]
			public int Estado { get; set; }

			[Display(Name = "Conectado")]
			public bool Conectado { get; set; }

			[Display(Name = "Persona")]
			public int Persona { get; set; }

			[Display(Name = "Cargo")]
			public int Cargo { get; set; }

			[Display(Name = "OrganismoUltimoIngreso")]
			public int? OrganismoUltimoIngreso { get; set; }

			[Display(Name = "SubAmbito")]
			public int? SubAmbito { get; set; }

			[Display(Name = "TieneFirma")]
			public bool TieneFirma { get; set; }

			[Display(Name = "NotificacionElectronica")]
			public bool NotificacionElectronica { get; set; }

			[Display(Name = "UsuarioAlta")]
			public int? UsuarioAlta { get; set; }

			[Display(Name = "UsuarioModifica")]
			public int? UsuarioModifica { get; set; }

			[Display(Name = "UsuarioElimina")]
			public int? UsuarioElimina { get; set; }

			[Display(Name = "FechaModificacion")]
			public DateTime? FechaModificacion { get; set; }

			[Display(Name = "FechaEliminacion")]
			public DateTime? FechaEliminacion { get; set; }

			[Display(Name = "AceptoTerminosCondiciones")]
			public bool AceptoTerminosCondiciones { get; set; }

			[Display(Name = "FechaTerminosCondiciones")]
			public DateTime? FechaTerminosCondiciones { get; set; }

			[Display(Name = "FechaSuspendidoDesde")]
			public DateTime? FechaSuspendidoDesde { get; set; }

			[Display(Name = "FechaSuspendidoHasta")]
			public DateTime? FechaSuspendidoHasta { get; set; }

            [Display(Name = "Es Subrogante")]
            public bool EsSubrogante { get; set; }
        #endregion


    }
}
