using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class MontosDeViaticosMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "FechaInicioVigencia")]
			public DateTime FechaInicioVigencia { get; set; }

			[Display(Name = "FuncionarioProvinciaUnDia")]
			public decimal FuncionarioProvinciaUnDia { get; set; }

			[Display(Name = "FuncionarioProvinciaMasUnDia")]
			public decimal FuncionarioProvinciaMasUnDia { get; set; }

			[Display(Name = "FuncionarioFueraUnDia")]
			public decimal FuncionarioFueraUnDia { get; set; }

			[Display(Name = "FuncionarioFueraMasUnDia")]
			public decimal FuncionarioFueraMasUnDia { get; set; }

			[Display(Name = "FuncionarioProvincia25Mayo")]
			public decimal FuncionarioProvincia25Mayo { get; set; }

			[Display(Name = "AgenteProvinciaUnDia1")]
			public decimal AgenteProvinciaUnDia1 { get; set; }

			[Display(Name = "AgenteProvinciaMasUnDia1")]
			public decimal AgenteProvinciaMasUnDia1 { get; set; }

			[Display(Name = "AgenteFueraUnDia1")]
			public decimal AgenteFueraUnDia1 { get; set; }

			[Display(Name = "AgenteProvincia25Mayo1")]
			public decimal AgenteProvincia25Mayo1 { get; set; }
			#endregion


	}
}
