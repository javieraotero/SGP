using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class CargosRefMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Nombre")]
			public string Descripcion { get; set; }

			[Display(Name = "Orden")]
			public int Orden { get; set; }

			[Display(Name = "Grupo")]
			public int Grupo { get; set; }

			[Display(Name = "Codigo RRHH")]
			public int? CodigoRRHH { get; set; }

			[Display(Name = "Presupuesto")]
			public int? Presupuesto { get; set; }
			#endregion


	}
}
