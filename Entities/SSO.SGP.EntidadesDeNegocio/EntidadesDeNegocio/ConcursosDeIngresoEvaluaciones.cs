
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
	[MetadataTypeAttribute(typeof(ConcursosDeIngresoEvaluacionesMetaData))]
	[Table("ConcursosDeIngresoEvaluaciones")]
	public partial class ConcursosDeIngresoEvaluaciones
	{
		#region Constructor
		public ConcursosDeIngresoEvaluaciones()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Concurso")]
		public int Concurso { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripción")]
		public string  Descripcion { get; set; }

		public DateTime? FechaInicio { get; set; }

		public DateTime? FechaFin { get; set; }

        public bool Activa { get; set; }

        public int? Cantidad_Preguntas { get; set; }

        public int? Porcentaje_Aprobacion { get; set; }
		#endregion

	}
}
