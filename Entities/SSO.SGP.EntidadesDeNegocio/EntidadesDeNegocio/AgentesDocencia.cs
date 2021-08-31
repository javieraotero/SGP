
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
	[MetadataTypeAttribute(typeof(AgentesDocenciaMetaData))]
	[Table("AgentesDocencia")]
	public partial class AgentesDocencia
	{
		#region Constructor
		public AgentesDocencia()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Agente")]
		public int Agente { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fecha")]
		public DateTime Fecha { get; set; }

		public string Institucion { get; set; }

		public int CargaHoraria { get; set; }

		public bool HorasCatedra { get; set; }

		public bool HorasSemanales { get; set; }

		public string Observaciones { get; set; }

        public string Detalle { get; set; }

        public string Periodo { get; set; }

        [ForeignKey("Agente")]
		public virtual Agentes Agentes { get; set; }
		#endregion

	}
}
