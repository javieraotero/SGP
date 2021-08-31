using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class ParametrosTrabajoCivilRefMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "CantidadRegistrosGrilla")]
			public int CantidadRegistrosGrilla { get; set; }

			[Display(Name = "Activo")]
			public bool Activo { get; set; }

			[Display(Name = "TimerMensajes")]
			public int TimerMensajes { get; set; }

			[Display(Name = "ExtensionesPermitidasArchivos")]
			public string ExtensionesPermitidasArchivos { get; set; }

			[Display(Name = "TamanoMaximoArchivos")]
			public int TamanoMaximoArchivos { get; set; }

			[Display(Name = "RedireccionarPorMantenimiento")]
			public bool RedireccionarPorMantenimiento { get; set; }

			[Display(Name = "CantidadMinutosGrabadoAutomaticoActuaciones")]
			public int CantidadMinutosGrabadoAutomaticoActuaciones { get; set; }

			[Display(Name = "InscMedComedXCircunscripcion")]
			public bool InscMedComedXCircunscripcion { get; set; }

			[Display(Name = "MateriasConCategoriaUnica")]
			public bool MateriasConCategoriaUnica { get; set; }
			#endregion


	}
}
