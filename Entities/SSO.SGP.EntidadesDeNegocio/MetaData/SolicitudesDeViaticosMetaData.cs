using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class SolicitudesDeViaticosMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Fecha")]
			public DateTime Fecha { get; set; }

			[Display(Name = "OrganismoSolicitante")]
			public int OrganismoSolicitante { get; set; }

			[Display(Name = "Destino")]
			public int Destino { get; set; }

			[Display(Name = "FechaDeInicio")]
			public DateTime FechaDeInicio { get; set; }

			[Display(Name = "FechaDeFin")]
			public DateTime FechaDeFin { get; set; }

			[Display(Name = "MedioDeTransporte")]
			public int MedioDeTransporte { get; set; }

			[Display(Name = "AutoOficial")]
			public int? AutoOficial { get; set; }

			[Display(Name = "ConChofer")]
			public bool ConChofer { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime FechaAlta { get; set; }

			[Display(Name = "UsuarioAlta")]
			public int UsuarioAlta { get; set; }

			[Display(Name = "FechaModifica")]
			public DateTime FechaModifica { get; set; }

			[Display(Name = "UsuarioModifica")]
			public int UsuarioModifica { get; set; }

			[Display(Name = "Estado")]
			public DateTime Estado { get; set; }

			[Display(Name = "MotivoDeComision")]
			public string MotivoDeComision { get; set; }

			[Display(Name = "Expediente")]
			public string Expediente { get; set; }

			[Display(Name = "Identificador")]
			public int Identificador { get; set; }
			#endregion


	}
}
