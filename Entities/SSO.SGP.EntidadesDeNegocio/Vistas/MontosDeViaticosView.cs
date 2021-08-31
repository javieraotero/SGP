using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class MontosDeViaticosView
	{
			#region Propiedades

			[Display(Name = "Id", Order = 0)]
			public int Id { get; set; }

			[Display(Name = "F.Inicio", Order = 10)]
			public DateTime FechaInicioVigencia { get; set; }

			[Display(Name = "F.Prov", Order = 10)]
			public decimal FuncionarioProvinciaUnDia { get; set; }

			[Display(Name = "F.Prov1", Order = 10)]
			public decimal FuncionarioProvinciaMasUnDia { get; set; }

			[Display(Name = "F.Fuera", Order = 10)]
			public decimal FuncionarioFueraUnDia { get; set; }

			[Display(Name = "F.Fuera1", Order = 10)]
			public decimal FuncionarioFueraMasUnDia { get; set; }

			[Display(Name = "F.25.Mayo", Order = 10)]
			public decimal FuncionarioProvincia25Mayo { get; set; }

			[Display(Name = "Ag.Prov", Order = 10)]
			public decimal AgenteProvinciaUnDia1 { get; set; }

			[Display(Name = "Ag.Prov1", Order = 10)]
			public decimal AgenteProvinciaMasUnDia1 { get; set; }

			[Display(Name = "Ag.Fuera1", Order = 10)]
			public decimal AgenteFueraUnDia1 { get; set; }

			#endregion


	}
}
