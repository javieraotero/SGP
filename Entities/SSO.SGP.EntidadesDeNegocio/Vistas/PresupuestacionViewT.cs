using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class PresupuestacionViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Causa")]
			public int Causa { get; set; }

			[Display(Name = "FechaPresu")]
			public DateTime FechaPresu { get; set; }

			[Display(Name = "CapitalTotal")]
			public decimal CapitalTotal { get; set; }

			[Display(Name = "InteresTotal")]
			public decimal InteresTotal { get; set; }

			[Display(Name = "InteresAplicado")]
			public decimal InteresAplicado { get; set; }

			[Display(Name = "TipoHonorario")]
			public string TipoHonorario { get; set; }

			[Display(Name = "IVA")]
			public bool IVA { get; set; }

			[Display(Name = "Capitaliza")]
			public bool Capitaliza { get; set; }

			[Display(Name = "HonorariosTotal")]
			public decimal HonorariosTotal { get; set; }

			[Display(Name = "GastosTotal")]
			public decimal GastosTotal { get; set; }

			[Display(Name = "FechaInicioEjecutivo")]
			public DateTime FechaInicioEjecutivo { get; set; }

			[Display(Name = "Activo")]
			public bool Activo { get; set; }

			[Display(Name = "UsuarioAlta")]
			public int UsuarioAlta { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime FechaAlta { get; set; }

			[Display(Name = "IVAIntereses")]
			public bool IVAIntereses { get; set; }
			#endregion


	}
}
