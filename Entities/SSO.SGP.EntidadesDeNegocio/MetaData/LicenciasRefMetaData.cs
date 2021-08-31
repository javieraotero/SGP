using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class LicenciasRefMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Nombre")]
			public string Descripcion { get; set; }

			[Display(Name = "Por A�o")]
			public int? PorAnio { get; set; }

			[Display(Name = "Por Licencia")]
			public int? PorLicencia { get; set; }

			[Display(Name = "Observaciones")]
			public string Observaciones { get; set; }

			[Display(Name = "Dias Acumulables?")]
			public bool DiasAcumulables { get; set; }

			[Display(Name = "Codigo RRHH")]
			public int CodigoRRHH { get; set; }

            [Display(Name = "Resetear transcurridos los d�as")]
            public int? ResetearDias { get; set; }

            [Display(Name = "Controlar licencia por Agente")]
            public bool PorAgente { get; set; }

            [Display(Name = "Exepci�n en D�as")]
            public int? DiasTopeExcepcion { get; set; }

            [Display(Name = "Unidad temporal de Excepci�n")]
            public int? TopeExcepcionUnidadTemporal { get; set; }

            [Display(Name = "D�as para reinicio de saldo")]
            public int? DiasParaReinicioDeSaldo { get; set; }

            [Display(Name = "Fecha de inicio de control")]
            public DateTime? FechaInicioDeControl { get; set; }

            [Display(Name = "Unidad temporal por a�o")]
            public int? UnidadTemporalPorAnio { get; set; }

            [Display(Name = "Unidad temporal por licencia")]
            public int? UnidadTemporalPorLicencia { get; set; }

            [Display(Name = "Unidad de contexto")]
            public int? UnidadDeContextoPorLicencia { get; set; }

            #endregion
	}
}
