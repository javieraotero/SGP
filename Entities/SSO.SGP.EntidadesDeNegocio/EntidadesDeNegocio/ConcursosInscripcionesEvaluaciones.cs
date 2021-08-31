
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
	[MetadataTypeAttribute(typeof(ConcursosInscripcionesEvaluacionesMetaData))]
	[Table("ConcursosInscripcionesEvaluaciones")]
	public partial class ConcursosInscripcionesEvaluaciones
	{
		#region Constructor
		public ConcursosInscripcionesEvaluaciones()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Evaluacion")]
		public int Evaluacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar DNI")]
		public long DNI { get; set; }

		[Required(ErrorMessage = "Debe ingresar Email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Debe ingresar CodigoDNI")]
		public string CodigoDNI { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaInicio")]
		public DateTime FechaInicio { get; set; }

		public DateTime? FechaEnvio { get; set; }

		[Required(ErrorMessage = "Debe ingresar ConfirmacionEmail")]
		public bool ConfirmacionEmail { get; set; }

		public DateTime? FechaConfirmacion { get; set; }

		public string Token { get; set; }

        public int Inscripcion { get; set; }

        public decimal? Porcentaje { get; set; }
		#endregion

	}
}
