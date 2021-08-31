using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class ConcursosDeIngresoRespuestasMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Pregunta")]
			public int Pregunta { get; set; }

			[Display(Name = "Respuesta")]
			public string Respuesta { get; set; }

			[Display(Name = "EsCorrecta")]
			public bool EsCorrecta { get; set; }

			[Display(Name = "Activa")]
			public bool Activa { get; set; }
			#endregion


	}
}
