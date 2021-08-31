
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
	[MetadataTypeAttribute(typeof(ExpedientesAnotacionesMetaData))]
	[Table("ExpedientesAnotaciones")]
	public partial class ExpedientesAnotaciones
	{
		#region Constructor
		public ExpedientesAnotaciones()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Expediente")]
		public int Expediente { get; set; }

		[Required(ErrorMessage = "Debe ingresar Titulo")]
		[StringLength(255, ErrorMessage ="Titulo no puede superar los 255 caracteres")]
		public string Titulo { get; set; }

		[StringLength(2147483647, ErrorMessage ="Fundamento no puede superar los 2147483647 caracteres")]
		public string Fundamento { get; set; }

		[Required(ErrorMessage = "Debe ingresar OficinaOrigen")]
		public int OficinaOrigen { get; set; }

		[Required(ErrorMessage = "Debe ingresar SubAmbitoOrigen")]
		public int SubAmbitoOrigen { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activo")]
		public bool Activo { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioAlta")]
		public int UsuarioAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioModifica")]
		public int UsuarioModifica { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaModifica")]
		public DateTime FechaModifica { get; set; }

		public DateTime? FechaElimina { get; set; }

		public int? UsuarioElimina { get; set; }

		[StringLength(2147483647, ErrorMessage ="FundamentoMax no puede superar los 2147483647 caracteres")]
		public string FundamentoMax { get; set; }

		[ForeignKey("Expediente")]
		public virtual Expedientes Expedientes { get; set; }

		[ForeignKey("OficinaOrigen")]
		public virtual OrganismosRef OficinaOrigens { get; set; }

		[ForeignKey("SubAmbitoOrigen")]
		public virtual Ambitos SubAmbitoOrigens { get; set; }

		[ForeignKey("UsuarioAlta")]
		public virtual Usuarios UsuarioAltas { get; set; }
		#endregion

	}
}
