
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
	[MetadataTypeAttribute(typeof(SolicitudesDeViaticosAgentesMetaData))]
	[Table("SolicitudesDeViaticosAgentes")]
	public partial class SolicitudesDeViaticosAgentes
	{
		#region Constructor
		public SolicitudesDeViaticosAgentes()
		{
			// Prueba de codigo
		} 
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar SolicitudDeViatico")]
		public int SolicitudDeViatico { get; set; }

		[Required(ErrorMessage = "Debe ingresar Agente")]
		public int Agente { get; set; }

		[Required(ErrorMessage = "Debe ingresar Dias")]
		public decimal Dias { get; set; }

		[Required(ErrorMessage = "Debe ingresar ImportePorDia")]
		public decimal ImportePorDia { get; set; }

		[Required(ErrorMessage = "Debe ingresar Subtotal")]
		public decimal Subtotal { get; set; }

		[Required(ErrorMessage = "Debe ingresar ImporteGastos")]
		public decimal ImporteGastos { get; set; }

		[Required(ErrorMessage = "Debe ingresar ImporteTotal")]
		public decimal ImporteTotal { get; set; }

        public string AgenteDescripcion { get; set; }
        public string CargoDescripcion { get; set; }
        public int? Grupo { get; set; }

		[ForeignKey("SolicitudDeViatico")]
		public virtual SolicitudesDeViaticos SolicitudDeViaticos { get; set; }

		[ForeignKey("Agente")]        
		public virtual Agentes Agentes { get; set; }
		#endregion

	}
}
