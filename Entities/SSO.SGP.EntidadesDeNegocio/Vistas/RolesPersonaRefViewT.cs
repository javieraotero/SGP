using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class RolesPersonaRefViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "Funcionario")]
			public bool Funcionario { get; set; }

			[Display(Name = "NotificaAutoAudiencia")]
			public bool NotificaAutoAudiencia { get; set; }

			[Display(Name = "EsUsuarioSistema")]
			public bool EsUsuarioSistema { get; set; }
			#endregion


	}
}
