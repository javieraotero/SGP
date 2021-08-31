
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
	[MetadataTypeAttribute(typeof(IncidentesMetaData))]
	[Table("Incidentes")]
	public partial class Incidentes
	{
		#region Constructor
		public Incidentes()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioSolicitante")]
		public int UsuarioSolicitante { get; set; }

		[Required(ErrorMessage = "Debe ingresar AmbitoSolicitante")]
		public int AmbitoSolicitante { get; set; }

		public int? SubambitoSolicitante { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaHoraSolicitud")]
		public DateTime FechaHoraSolicitud { get; set; }

		[Required(ErrorMessage = "Debe ingresar EstadoActual")]
		public int EstadoActual { get; set; }

		public DateTime? FechaUltimoCambioEstado { get; set; }

		[Required(ErrorMessage = "Debe ingresar Prioridad")]
		public int Prioridad { get; set; }

		[Required(ErrorMessage = "Debe ingresar Titulo")]
		[StringLength(50, ErrorMessage ="Titulo no puede superar los 50 caracteres")]
		public string Titulo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Problema")]
		[StringLength(2147483647, ErrorMessage ="Problema no puede superar los 2147483647 caracteres")]
		public string Problema { get; set; }

		[StringLength(2147483647, ErrorMessage ="Observaciones no puede superar los 2147483647 caracteres")]
		public string Observaciones { get; set; }

		[StringLength(50, ErrorMessage ="Version no puede superar los 50 caracteres")]
		public string Version { get; set; }

		[StringLength(255, ErrorMessage ="Etiquetas no puede superar los 255 caracteres")]
		public string Etiquetas { get; set; }

		public int? TesteadoUsuario { get; set; }

		public int? TesteadoDesarrollador { get; set; }

		public int? TesteadoSupervisor { get; set; }

		public int? Desarrollador { get; set; }

		public int? PrioridadDesarrollo { get; set; }

		public virtual ICollection<IncidentesEstado> IncidentesEstado { get; set; }

		[ForeignKey("UsuarioSolicitante")]
		public virtual Usuarios UsuarioSolicitantes { get; set; }

		[ForeignKey("AmbitoSolicitante")]
		public virtual Ambitos AmbitoSolicitantes { get; set; }

		[ForeignKey("SubambitoSolicitante")]
		public virtual Ambitos SubambitoSolicitantes { get; set; }

		[ForeignKey("EstadoActual")]
		public virtual EstadosIncidentes EstadoActuals { get; set; }

		[ForeignKey("TesteadoUsuario")]
		public virtual Usuarios TesteadoUsuarios { get; set; }

		[ForeignKey("TesteadoDesarrollador")]
		public virtual Usuarios TesteadoDesarrolladors { get; set; }

		[ForeignKey("TesteadoSupervisor")]
		public virtual Usuarios TesteadoSupervisors { get; set; }

		[ForeignKey("Desarrollador")]
		public virtual Usuarios Desarrolladors { get; set; }
		#endregion

	}
}
