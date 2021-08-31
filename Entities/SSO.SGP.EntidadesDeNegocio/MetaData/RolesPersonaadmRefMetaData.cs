using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class RolesPersonaadmRefMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "Funcionario")]
			public bool Funcionario { get; set; }

			[Display(Name = "EsUsuarioSistema")]
			public bool EsUsuarioSistema { get; set; }
			#endregion


	}
}
