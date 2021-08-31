using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class OrganismosSecuenciaRefMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "OrganismoOrigen")]
			public int OrganismoOrigen { get; set; }

			[Display(Name = "OrganismoDestino")]
			public int OrganismoDestino { get; set; }
			#endregion


	}
}
