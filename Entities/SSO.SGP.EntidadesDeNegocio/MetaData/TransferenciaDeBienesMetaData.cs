using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class TransferenciaDeBienesMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "IdBien")]
			public int IdBien { get; set; }

			[Display(Name = "Origen")]
			public int? Origen { get; set; }

			[Display(Name = "Destino")]
			public int? Destino { get; set; }

			[Display(Name = "Fecha")]
			public DateTime? Fecha { get; set; }

			[Display(Name = "Expediente")]
			public int? Expediente { get; set; }

			[Display(Name = "PlanillaDeTransferencia")]
			public int? PlanillaDeTransferencia { get; set; }

			[Display(Name = "FechaDeAlta")]
			public DateTime? FechaDeAlta { get; set; }

			[Display(Name = "ResponsablePrimario")]
			public int? ResponsablePrimario { get; set; }

			[Display(Name = "ResponsableSecundario")]
			public int? ResponsableSecundario { get; set; }

			[Display(Name = "ResponsableDeUso")]
			public int? ResponsableDeUso { get; set; }

			[Display(Name = "ResponsablePrimarioAnterior")]
			public int? ResponsablePrimarioAnterior { get; set; }

			[Display(Name = "ResponsableSecundarioAnterior")]
			public int? ResponsableSecundarioAnterior { get; set; }

			[Display(Name = "ResponsableDeUsoAnterior")]
			public int? ResponsableDeUsoAnterior { get; set; }

			[Display(Name = "FechaDeCreacion")]
			public DateTime? FechaDeCreacion { get; set; }

			[Display(Name = "Estado")]
			public int? Estado { get; set; }

			[Display(Name = "Control")]
			public bool Control { get; set; }

			[Display(Name = "ExpedienteProvincia")]
			public string ExpedienteProvincia { get; set; }

			[Display(Name = "OrganizacionCreadora")]
			public int? OrganizacionCreadora { get; set; }
			#endregion


	}
}
