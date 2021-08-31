
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
	//[MetadataTypeAttribute(typeof(FuerosRefMetaData))]
	[Table("OrganismosExtensionesRRHH")]
	public partial class OrganismosExtensionesRRHH
    {
		#region Constructor
		public OrganismosExtensionesRRHH()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		public int Organismo { get; set; }

        public int? Agente { get; set; }

        public int? AutoPropioViaticos { get; set; }

		public DateTime? FechaHasta { get; set; }

		public int? DependeDe { get; set; }

		public int? CargoOrigen { get; set; }

		public int? CargoDestino { get; set; }

		//Diego
		//public virtual ICollection<Ambitos> Ambitos { get; set; }

		//public virtual ICollection<ArchivoExpediente> ArchivoExpediente { get; set; }
		#endregion

	}
}
