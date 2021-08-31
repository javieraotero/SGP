
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
	[MetadataTypeAttribute(typeof(ConcursosDeIngresoPreguntasMetaData))]
	[Table("ConcursosDeIngresoPreguntas")]
	public partial class ConcursosDeIngresoPreguntas
	{
		#region Constructor
		public ConcursosDeIngresoPreguntas()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Pregunta")]
		public string Pregunta { get; set; }

		[Required(ErrorMessage = "Debe ingresar Evaluacion")]
		public int Evaluacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activa")]
		public bool Activa { get; set; }

		[Required(ErrorMessage = "Debe ingresar Orden")]
		public int Orden { get; set; }
        #endregion

    }
}
