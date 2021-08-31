
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
	[MetadataTypeAttribute(typeof(ParametrosTrabajoCivilRefMetaData))]
	[Table("ParametrosTrabajoCivilRef")]
	public partial class ParametrosTrabajoCivilRef
	{
		#region Constructor
		public ParametrosTrabajoCivilRef()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar CantidadRegistrosGrilla")]
		public int CantidadRegistrosGrilla { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activo")]
		public bool Activo { get; set; }

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

		[Required(ErrorMessage = "Debe ingresar InscMedComedXCircunscripcion")]
		public bool InscMedComedXCircunscripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar MateriasConCategoriaUnica")]
		public bool MateriasConCategoriaUnica { get; set; }
		#endregion

	}
}
