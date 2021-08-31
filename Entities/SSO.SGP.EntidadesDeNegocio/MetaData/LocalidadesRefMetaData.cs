using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class LocalidadesRefMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "CodigoPostal")]
			public string CodigoPostal { get; set; }

			[Display(Name = "Provincia")]
			public int Provincia { get; set; }

			[Display(Name = "Abreviatura")]
			public string Abreviatura { get; set; }

			[Display(Name = "TieneCallesCargadas")]
			public bool TieneCallesCargadas { get; set; }
			#endregion


	}
}
