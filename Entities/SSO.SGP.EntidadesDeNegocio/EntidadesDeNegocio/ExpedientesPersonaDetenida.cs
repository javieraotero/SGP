
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
	[MetadataTypeAttribute(typeof(ExpedientesPersonaDetenidaMetaData))]
	[Table("ExpedientesPersonaDetenida")]
	public partial class ExpedientesPersonaDetenida
	{
		#region Constructor
		public ExpedientesPersonaDetenida()
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

		public int? LugarDetencion { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaDesde")]
		public DateTime FechaDesde { get; set; }

		public DateTime? FechaHasta { get; set; }

		[StringLength(300, ErrorMessage ="Observaciones no puede superar los 300 caracteres")]
		public string Observaciones { get; set; }

		[Required(ErrorMessage = "Debe ingresar Anulada")]
		public bool Anulada { get; set; }

		[Required(ErrorMessage = "Debe ingresar MedidaSustitutiva")]
		public bool MedidaSustitutiva { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioAlta")]
		public int UsuarioAlta { get; set; }

		public DateTime? FechaModificacion { get; set; }

		public int? UsuarioModifica { get; set; }

		public DateTime? FechaAnula { get; set; }

		public int? UsuarioAnula { get; set; }

		public int? DenidoPorOficinaJudicial { get; set; }

		[Required(ErrorMessage = "Debe ingresar Anulada72HS")]
		public bool Anulada72HS { get; set; }

		[ForeignKey("Expediente")]
		public virtual Expedientes Expedientes { get; set; }

		[ForeignKey("Persona")]
		public virtual Personas Personas { get; set; }

		[ForeignKey("LugarDetencion")]
		public virtual OrganismosRef LugarDetencions { get; set; }

		[ForeignKey("UsuarioAlta")]
		public virtual Usuarios UsuarioAltas { get; set; }
		#endregion

	}
}
