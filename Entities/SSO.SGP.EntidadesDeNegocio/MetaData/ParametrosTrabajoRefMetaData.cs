using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class ParametrosTrabajoRefMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "CantidadRegistrosGrilla")]
			public int CantidadRegistrosGrilla { get; set; }

			[Display(Name = "CantidadDiasAlertaPreventivo")]
			public int CantidadDiasAlertaPreventivo { get; set; }

			[Display(Name = "CantidadDiasAlertaSumarioPrevencion")]
			public int CantidadDiasAlertaSumarioPrevencion { get; set; }

			[Display(Name = "CantidadMinutosBloqueoExpediente")]
			public int CantidadMinutosBloqueoExpediente { get; set; }

			[Display(Name = "CantidadMinutosBloqueoActuacion")]
			public int CantidadMinutosBloqueoActuacion { get; set; }

			[Display(Name = "CantidadMinutosBloqueoUsuario")]
			public int CantidadMinutosBloqueoUsuario { get; set; }

			[Display(Name = "TipoActuacionInicioExpedienteFiscal")]
			public int? TipoActuacionInicioExpedienteFiscal { get; set; }

			[Display(Name = "Activo")]
			public bool Activo { get; set; }

			[Display(Name = "CantMaxDefensor")]
			public int? CantMaxDefensor { get; set; }

			[Display(Name = "OficioLibertadComun")]
			public int? OficioLibertadComun { get; set; }

			[Display(Name = "OficioLibertadConRestricciones")]
			public int? OficioLibertadConRestricciones { get; set; }

			[Display(Name = "ActaConstitucionDomicilio")]
			public int? ActaConstitucionDomicilio { get; set; }

			[Display(Name = "ActaConstitucionDomicilioConRestricciones")]
			public int? ActaConstitucionDomicilioConRestricciones { get; set; }

			[Display(Name = "OficioComisariaMujer")]
			public int? OficioComisariaMujer { get; set; }

			[Display(Name = "OficioCapturayDetencion")]
			public int? OficioCapturayDetencion { get; set; }

			[Display(Name = "OficioInmediataLibertad")]
			public int? OficioInmediataLibertad { get; set; }

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

			[Display(Name = "ModeloPoliciaDenuncia")]
			public int? ModeloPoliciaDenuncia { get; set; }

			[Display(Name = "PlantillaDenunciaPolicial")]
			public int? PlantillaDenunciaPolicial { get; set; }

			[Display(Name = "ModeloDeclaracionImputados")]
			public int? ModeloDeclaracionImputados { get; set; }
			#endregion


	}
}
