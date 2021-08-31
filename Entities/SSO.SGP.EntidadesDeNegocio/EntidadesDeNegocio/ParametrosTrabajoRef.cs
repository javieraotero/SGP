
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
	[MetadataTypeAttribute(typeof(ParametrosTrabajoRefMetaData))]
	[Table("ParametrosTrabajoRef")]
	public partial class ParametrosTrabajoRef
	{
		#region Constructor
		public ParametrosTrabajoRef()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar CantidadRegistrosGrilla")]
		public int CantidadRegistrosGrilla { get; set; }

		[Required(ErrorMessage = "Debe ingresar CantidadDiasAlertaPreventivo")]
		public int CantidadDiasAlertaPreventivo { get; set; }

		[Required(ErrorMessage = "Debe ingresar CantidadDiasAlertaSumarioPrevencion")]
		public int CantidadDiasAlertaSumarioPrevencion { get; set; }

		[Required(ErrorMessage = "Debe ingresar CantidadMinutosBloqueoExpediente")]
		public int CantidadMinutosBloqueoExpediente { get; set; }

		[Required(ErrorMessage = "Debe ingresar CantidadMinutosBloqueoActuacion")]
		public int CantidadMinutosBloqueoActuacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar CantidadMinutosBloqueoUsuario")]
		public int CantidadMinutosBloqueoUsuario { get; set; }

		public int? TipoActuacionInicioExpedienteFiscal { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activo")]
		public bool Activo { get; set; }

		public int? CantMaxDefensor { get; set; }

		public int? OficioLibertadComun { get; set; }

		public int? OficioLibertadConRestricciones { get; set; }

		public int? ActaConstitucionDomicilio { get; set; }

		public int? ActaConstitucionDomicilioConRestricciones { get; set; }

		public int? OficioComisariaMujer { get; set; }

		public int? OficioCapturayDetencion { get; set; }

		public int? OficioInmediataLibertad { get; set; }

		[Required(ErrorMessage = "Debe ingresar TimerMensajes")]
		public int TimerMensajes { get; set; }

		[Required(ErrorMessage = "Debe ingresar ExtensionesPermitidasArchivos")]
		[StringLength(150, ErrorMessage ="ExtensionesPermitidasArchivos no puede superar los 150 caracteres")]
		public string ExtensionesPermitidasArchivos { get; set; }

		[Required(ErrorMessage = "Debe ingresar TamanoMaximoArchivos")]
		public int TamanoMaximoArchivos { get; set; }

		[Required(ErrorMessage = "Debe ingresar RedireccionarPorMantenimiento")]
		public bool RedireccionarPorMantenimiento { get; set; }

		[Required(ErrorMessage = "Debe ingresar CantidadMinutosGrabadoAutomaticoActuaciones")]
		public int CantidadMinutosGrabadoAutomaticoActuaciones { get; set; }

		public int? ModeloPoliciaDenuncia { get; set; }

		public int? PlantillaDenunciaPolicial { get; set; }

		public int? ModeloDeclaracionImputados { get; set; }

		[ForeignKey("TipoActuacionInicioExpedienteFiscal")]
		public virtual TiposActuacionRef TipoActuacionInicioExpedienteFiscals { get; set; }

		[ForeignKey("OficioLibertadComun")]
		public virtual ModelosEscrito OficioLibertadComuns { get; set; }

		[ForeignKey("OficioLibertadConRestricciones")]
		public virtual ModelosEscrito OficioLibertadConRestriccioness { get; set; }

		[ForeignKey("ActaConstitucionDomicilio")]
		public virtual ModelosEscrito ActaConstitucionDomicilios { get; set; }

		[ForeignKey("ActaConstitucionDomicilioConRestricciones")]
		public virtual ModelosEscrito ActaConstitucionDomicilioConRestriccioness { get; set; }

		[ForeignKey("OficioComisariaMujer")]
		public virtual ModelosEscrito OficioComisariaMujers { get; set; }

		[ForeignKey("OficioCapturayDetencion")]
		public virtual ModelosEscrito OficioCapturayDetencions { get; set; }

		[ForeignKey("OficioInmediataLibertad")]
		public virtual ModelosEscrito OficioInmediataLibertads { get; set; }
		#endregion

	}
}
