
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
	//[MetadataTypeAttribute(typeof(ConcursosDeIngresoPreguntasMetaData))]
	[Table("ConcursosDeIngresoPreguntasInscripto")]
	public partial class ConcursosDeIngresoPreguntasInscripto
    {
		#region Constructor
		public ConcursosDeIngresoPreguntasInscripto()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

    	public int InscripcionEvaluacion { get; set; }

        public int Pregunta { get; set; }
	}
    #endregion
}