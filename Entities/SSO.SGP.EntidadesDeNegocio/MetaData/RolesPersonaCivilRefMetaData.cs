using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class RolesPersonaCivilRefMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "Tipo")]
			public int Tipo { get; set; }

			[Display(Name = "NotificaAutoAudiencia")]
			public bool NotificaAutoAudiencia { get; set; }
			#endregion


	}
}
