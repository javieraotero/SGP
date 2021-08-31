using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class ArchivoExpedientePasesMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Expediente")]
			public int? Expediente { get; set; }

			[Display(Name = "OrganismoEnvio")]
			public int OrganismoEnvio { get; set; }

			[Display(Name = "UsuarioEnvio")]
			public int UsuarioEnvio { get; set; }

			[Display(Name = "FechaEnvio")]
			public DateTime FechaEnvio { get; set; }

			[Display(Name = "OrganismoRecepcion")]
			public int OrganismoRecepcion { get; set; }

			[Display(Name = "UsuarioRecepcion")]
			public int? UsuarioRecepcion { get; set; }

			[Display(Name = "FechaRecepcion")]
			public DateTime? FechaRecepcion { get; set; }

			[Display(Name = "Recibido")]
			public bool Recibido { get; set; }

			[Display(Name = "PaseAnterior")]
			public int? PaseAnterior { get; set; }

			[Display(Name = "PaseSiguiente")]
			public int? PaseSiguiente { get; set; }

			[Display(Name = "Observaciones")]
			public string Observaciones { get; set; }

			[Display(Name = "ArchivoExpediente")]
			public int ArchivoExpediente { get; set; }
			#endregion


	}
}
