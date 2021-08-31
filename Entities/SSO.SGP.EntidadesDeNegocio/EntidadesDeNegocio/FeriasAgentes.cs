
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
	[MetadataTypeAttribute(typeof(FeriasAgentesMetaData))]
	[Table("FeriasAgentes")]
	public partial class FeriasAgentes
	{
		#region Constructor
		public FeriasAgentes()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Agente")]
		public int Agente { get; set; }

		[Required(ErrorMessage = "Debe ingresar Feria")]
		public int Feria { get; set; }

		[Required(ErrorMessage = "Debe ingresar Dias")]
		public int Dias { get; set; }

		[Required(ErrorMessage = "Debe ingresar Desde1")]
		public DateTime Desde1 { get; set; }

		public DateTime? Desde2 { get; set; }

		public DateTime? Desde3 { get; set; }

		[Required(ErrorMessage = "Debe ingresar Hasta1")]
		public DateTime Hasta1 { get; set; }

		public DateTime? Hasta2 { get; set; }

		public DateTime? Hasta3 { get; set; }

		[Required(ErrorMessage = "Debe ingresar Instancia")]
		public int Instancia { get; set; }

        public string Observaciones { get; set; }

        public bool SinEfecto { get; set; }

		[ForeignKey("Agente")]
		public virtual Agentes Agentes { get; set; }

		[ForeignKey("Feria")]
		public virtual FeriasRef Ferias { get; set; }
		#endregion

	}
}
