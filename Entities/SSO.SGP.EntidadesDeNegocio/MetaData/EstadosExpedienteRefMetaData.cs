using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class EstadosExpedienteRefMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "GrupoEstado")]
			public int GrupoEstado { get; set; }

			[Display(Name = "Finaliza")]
			public bool Finaliza { get; set; }
			#endregion


	}
}
