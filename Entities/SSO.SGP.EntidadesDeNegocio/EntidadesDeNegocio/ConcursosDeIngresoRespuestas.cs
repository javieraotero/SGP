
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
	[MetadataTypeAttribute(typeof(ConcursosDeIngresoRespuestasMetaData))]
	[Table("ConcursosDeIngresoRespuestas")]
	public partial class ConcursosDeIngresoRespuestas
	{
		#region Constructor
		public ConcursosDeIngresoRespuestas()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Pregunta")]
		public int Pregunta { get; set; }

		[Required(ErrorMessage = "Debe ingresar Respuesta")]
		public string Respuesta { get; set; }

		[Required(ErrorMessage = "Debe ingresar EsCorrecta")]
		public bool EsCorrecta { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activa")]
		public bool Activa { get; set; }
		#endregion

	}
}
