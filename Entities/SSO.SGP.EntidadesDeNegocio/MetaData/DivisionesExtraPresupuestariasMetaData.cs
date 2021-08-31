using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class DivisionesExtraPresupuestariasMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Nombre")]
			public string Nombre { get; set; }

			[Display(Name = "CodigoCESIDA")]
			public string CodigoCESIDA { get; set; }

			[Display(Name = "PartidaPresupuestaria")]
			public int PartidaPresupuestaria { get; set; }
			#endregion


	}
}
