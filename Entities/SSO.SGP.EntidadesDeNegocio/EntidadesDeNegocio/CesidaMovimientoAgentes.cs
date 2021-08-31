
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
	[MetadataTypeAttribute(typeof(CesidaMovimientoAgentesMetaData))]
	[Table("CesidaMovimientoAgentes")]
	public partial class CesidaMovimientoAgentes
	{
		#region Constructor
		public CesidaMovimientoAgentes()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Agente")]
		public int Agente { get; set; }

		[Required(ErrorMessage = "Debe ingresar Movimiento")]
		public int Movimiento { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioAlta")]
		public int UsuarioAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar Autorizado")]
		public bool Autorizado { get; set; }

		public string MensajeRespuesta { get; set; }

		public int? NroLote { get; set; }

		public int? CodOperacion { get; set; }

		public int? Persona { get; set; }

		public DateTime? FechaEnvio { get; set; }

		public DateTime? FechaAutoriza { get; set; }

		public int? UsuarioAutoriza { get; set; }

        public int? Nombramiento { get; set; }

		[ForeignKey("Agente")]
		public virtual Agentes Agentes { get; set; }
		#endregion

	}
}
