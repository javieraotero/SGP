using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class ElementosSecuestradosMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Expediente")]
			public int Expediente { get; set; }

			[Display(Name = "Codigo")]
			public string Codigo { get; set; }

			[Display(Name = "Deposito")]
			public int Deposito { get; set; }

			[Display(Name = "NroEstanteria")]
			public string NroEstanteria { get; set; }

			[Display(Name = "NroEstante")]
			public string NroEstante { get; set; }

			[Display(Name = "DescirpcionDetallada")]
			public string DescirpcionDetallada { get; set; }

			[Display(Name = "Estado")]
			public int Estado { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime FechaAlta { get; set; }

			[Display(Name = "Usuario")]
			public int Usuario { get; set; }

			[Display(Name = "Observaciones")]
			public string Observaciones { get; set; }

			[Display(Name = "Caja")]
			public string Caja { get; set; }
			#endregion


	}
}
