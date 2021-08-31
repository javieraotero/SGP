
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
	[MetadataTypeAttribute(typeof(SaldosDeLicenciasOrdinariasMetaData))]
	[Table("SaldosDeLicenciasOrdinarias")]
	public partial class SaldosDeLicenciasOrdinarias
	{
		#region Constructor
		public SaldosDeLicenciasOrdinarias()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Agente")]
		public int Agente { get; set; }

		[Required(ErrorMessage = "Debe ingresar Anio")]
		public int Anio { get; set; }

		[Required(ErrorMessage = "Debe ingresar DiasTrabajados")]
		public int DiasTrabajados { get; set; }

		[Required(ErrorMessage = "Debe ingresar DiasUtilizados")]
		public int DiasUtilizados { get; set; }

		[Required(ErrorMessage = "Debe ingresar Enero")]
		public bool Enero { get; set; }

		[Required(ErrorMessage = "Debe ingresar Julio")]
		public bool Julio { get; set; }

		[ForeignKey("Agente")]
		public virtual Agentes Agentes { get; set; }
		#endregion

	}
}
