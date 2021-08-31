
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
	[MetadataTypeAttribute(typeof(SolicitudesDeViaticosRendicionesAgentesMetaData))]
	[Table("SolicitudesDeViaticosRendicionesAgentes")]
	public partial class SolicitudesDeViaticosRendicionesAgentes
	{
		#region Constructor
		public SolicitudesDeViaticosRendicionesAgentes()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Rendicion")]
		public int Rendicion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Agente")]
		public int Agente { get; set; }

		[Required(ErrorMessage = "Debe ingresar Dias")]
		public decimal Dias { get; set; }

		[Required(ErrorMessage = "Debe ingresar ImportePorDia")]
		public decimal ImportePorDia { get; set; }

		[Required(ErrorMessage = "Debe ingresar Subtotal")]
		public decimal Subtotal { get; set; }

		[Required(ErrorMessage = "Debe ingresar Gastos")]
		public decimal Gastos { get; set; }

		[Required(ErrorMessage = "Debe ingresar Anticipo")]
		public decimal Anticipo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Cobrar")]
		public decimal Cobrar { get; set; }

		[Required(ErrorMessage = "Debe ingresar Devolver")]
		public decimal Devolver { get; set; }

		[ForeignKey("Rendicion")]
		public virtual SolicitudesDeViaticosRendiciones Rendicions { get; set; }

		[ForeignKey("Agente")]
		public virtual Agentes Agentes { get; set; }
		#endregion

	}
}
