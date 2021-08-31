
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SSO.SGP.MetaData;


namespace SSO.SGP.EntidadesDeNegocio
{
	/// <summary>
	/// Entidad Generada por el Generador de codigo.
	/// </summary>
	[MetadataTypeAttribute(typeof(MontosDeViaticosMetaData))]
	[Table("MontosDeViaticos")]
	public partial class MontosDeViaticos
	{
		#region Constructor
		public MontosDeViaticos()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaInicioVigencia")]
		public DateTime FechaInicioVigencia { get; set; }

		[Required(ErrorMessage = "Debe ingresar FuncionarioProvinciaUnDia")]
		public decimal FuncionarioProvinciaUnDia { get; set; }

		[Required(ErrorMessage = "Debe ingresar FuncionarioProvinciaMasUnDia")]
		public decimal FuncionarioProvinciaMasUnDia { get; set; }

		[Required(ErrorMessage = "Debe ingresar FuncionarioFueraUnDia")]
		public decimal FuncionarioFueraUnDia { get; set; }

		[Required(ErrorMessage = "Debe ingresar FuncionarioFueraMasUnDia")]
		public decimal FuncionarioFueraMasUnDia { get; set; }

		[Required(ErrorMessage = "Debe ingresar FuncionarioProvincia25Mayo")]
		public decimal FuncionarioProvincia25Mayo { get; set; }

		[Required(ErrorMessage = "Debe ingresar AgenteProvinciaUnDia1")]
		public decimal AgenteProvinciaUnDia1 { get; set; }

		[Required(ErrorMessage = "Debe ingresar AgenteProvinciaMasUnDia1")]
		public decimal AgenteProvinciaMasUnDia1 { get; set; }

		[Required(ErrorMessage = "Debe ingresar AgenteFueraUnDia1")]
		public decimal AgenteFueraUnDia1 { get; set; }

		[Required(ErrorMessage = "Debe ingresar AgenteProvincia25Mayo1")]
		public decimal AgenteProvincia25Mayo1 { get; set; }
		#endregion

	}
}
