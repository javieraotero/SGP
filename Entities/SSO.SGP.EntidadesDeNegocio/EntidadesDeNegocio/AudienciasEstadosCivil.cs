
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
	[MetadataTypeAttribute(typeof(AudienciasEstadosCivilMetaData))]
	[Table("AudienciasEstadosCivil")]
	public partial class AudienciasEstadosCivil
	{
		#region Constructor
		public AudienciasEstadosCivil()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Audiencia")]
		public int Audiencia { get; set; }

		public DateTime? Fecha { get; set; }

		[StringLength(5, ErrorMessage ="HoraInicio no puede superar los 5 caracteres")]
		public string HoraInicio { get; set; }

		[StringLength(5, ErrorMessage ="HoraFin no puede superar los 5 caracteres")]
		public string HoraFin { get; set; }

		[Required(ErrorMessage = "Debe ingresar Estado")]
		public int Estado { get; set; }

		public int? Sala { get; set; }

		[StringLength(255, ErrorMessage ="Observaciones no puede superar los 255 caracteres")]
		public string Observaciones { get; set; }

		[Required(ErrorMessage = "Debe ingresar Usuario")]
		public int Usuario { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

		public int? MotivoCancelacion { get; set; }

		public int? MotivoPostergacion { get; set; }

		public virtual ICollection<AudienciasNotificacionCivil> AudienciasNotificacionCivilAudienciasEstados { get; set; }

		[ForeignKey("Audiencia")]
		public virtual AudienciasCivil Audiencias { get; set; }

		[ForeignKey("Estado")]
		public virtual EstadosAudienciaRef Estados { get; set; }

		[ForeignKey("Sala")]
		public virtual OrganismosRef Salas { get; set; }

		[ForeignKey("Usuario")]
		public virtual Usuarios Usuarios { get; set; }

		[ForeignKey("MotivoCancelacion")]
		public virtual MotivosCancelacionCivilRef MotivoCancelacions { get; set; }

		[ForeignKey("MotivoPostergacion")]
		public virtual MotivosPostergacionCivilRef MotivoPostergacions { get; set; }
		#endregion

	}
}
