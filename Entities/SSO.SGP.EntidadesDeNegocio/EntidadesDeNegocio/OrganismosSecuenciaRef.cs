
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
	[MetadataTypeAttribute(typeof(OrganismosSecuenciaRefMetaData))]
	[Table("OrganismosSecuenciaRef")]
	public partial class OrganismosSecuenciaRef
	{
		#region Constructor
		public OrganismosSecuenciaRef()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar OrganismoOrigen")]
		public int OrganismoOrigen { get; set; }

		[Required(ErrorMessage = "Debe ingresar OrganismoDestino")]
		public int OrganismoDestino { get; set; }

		[ForeignKey("OrganismoOrigen")]
		public virtual OrganismosRef OrganismoOrigens { get; set; }

		[ForeignKey("OrganismoDestino")]
		public virtual OrganismosRef OrganismoDestinos { get; set; }
		#endregion

	}
}
