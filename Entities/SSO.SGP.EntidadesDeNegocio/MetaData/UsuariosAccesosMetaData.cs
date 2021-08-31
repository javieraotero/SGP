using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class UsuariosAccesosMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Usuario")]
			public int Usuario { get; set; }

			[Display(Name = "Fecha")]
			public DateTime Fecha { get; set; }

			[Display(Name = "Ip")]
			public string Ip { get; set; }

			[Display(Name = "Intentos")]
			public int Intentos { get; set; }

			[Display(Name = "Navegador")]
			public string Navegador { get; set; }

			[Display(Name = "Organismo")]
			public int? Organismo { get; set; }
			#endregion


	}
}
