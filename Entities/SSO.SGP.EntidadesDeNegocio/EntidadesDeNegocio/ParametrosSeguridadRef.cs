
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
	[MetadataTypeAttribute(typeof(ParametrosSeguridadRefMetaData))]
	[Table("ParametrosSeguridadRef")]
	public partial class ParametrosSeguridadRef
	{
		#region Constructor
		public ParametrosSeguridadRef()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		[StringLength(50, ErrorMessage ="Descripcion no puede superar los 50 caracteres")]
		public string Descripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar CambioClavePrimerInicio")]
		public bool CambioClavePrimerInicio { get; set; }

		[Required(ErrorMessage = "Debe ingresar LongitudMinimaClave")]
		public int LongitudMinimaClave { get; set; }

		[Required(ErrorMessage = "Debe ingresar ClavesAlfanumericasObligatorias")]
		public bool ClavesAlfanumericasObligatorias { get; set; }

		[Required(ErrorMessage = "Debe ingresar IntervaloCaducidadClave")]
		public int IntervaloCaducidadClave { get; set; }

		[Required(ErrorMessage = "Debe ingresar MaximoIntentosAccesoFallidos")]
		public int MaximoIntentosAccesoFallidos { get; set; }

		[Required(ErrorMessage = "Debe ingresar DiasInactividadBloqueo")]
		public int DiasInactividadBloqueo { get; set; }

		[Required(ErrorMessage = "Debe ingresar ClavesEnRegistroHistorico")]
		public int ClavesEnRegistroHistorico { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activo")]
		public bool Activo { get; set; }
		#endregion

	}
}
