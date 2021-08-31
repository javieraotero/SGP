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

			[Display(Name = "Por Año")]
			public int? PorAnio { get; set; }

			[Display(Name = "Por Licencia")]
			public int? PorLicencia { get; set; }

			[Display(Name = "Observaciones")]
			public string Observaciones { get; set; }

			[Display(Name = "Dias Acumulables?")]
			public bool DiasAcumulables { get; set; }

			[Display(Name = "Codigo RRHH")]
			public int CodigoRRHH { get; set; }

            [Display(Name = "Resetear transcurridos los días")]
            public int? ResetearDias { get; set; }

            [Display(Name = "Controlar licencia por Agente")]
            public bool PorAgente { get; set; }

            [Display(Name = "Exepción en Días")]
            public int? DiasTopeExcepcion { get; set; }

            [Display(Name = "Unidad temporal de Excepción")]
            public int? TopeExcepcionUnidadTemporal { get; set; }

            [Display(Name = "Días para reinicio de saldo")]
            public int? DiasParaReinicioDeSaldo { get; set; }

            [Display(Name = "Fecha de inicio de control")]
            public DateTime? FechaInicioDeControl { get; set; }

            [Display(Name = "Unidad temporal por año")]
            public int? UnidadTemporalPorAnio { get; set; }

            [Display(Name = "Unidad temporal por licencia")]
            public int? UnidadTemporalPorLicencia { get; set; }

            [Display(Name = "Unidad de contexto")]
            public int? UnidadDeContextoPorLicencia { get; set; }

            #endregion
	}
}
