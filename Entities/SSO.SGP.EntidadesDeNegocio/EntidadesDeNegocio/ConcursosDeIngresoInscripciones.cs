
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
	[MetadataTypeAttribute(typeof(ConcursosDeIngresoInscripcionesMetaData))]
	[Table("ConcursosDeIngresoInscripciones")]
	public partial class ConcursosDeIngresoInscripciones
	{
		#region Constructor
		public ConcursosDeIngresoInscripciones()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar ConcursoDeIngreso")]
		public int ConcursoDeIngreso { get; set; }

		public DateTime? FechaPreinscripcion { get; set; }

		public string Apellido { get; set; }

		public string Nombres { get; set; }

		public long? DNI { get; set; }

		public DateTime? FechaDeNacimiento { get; set; }

		public string Domicilio { get; set; }

		public string Ciudad { get; set; }

		public string Provincia { get; set; }

		public string Telefono { get; set; }

		public string Email { get; set; }

		public string TituloSecundario { get; set; }

		public string ExpedidoPor { get; set; }

		public DateTime? FechaExpedido { get; set; }

		public string TituloUniversitario { get; set; }

		public DateTime? TituloUniversitarioFecha { get; set; }

		public string TituloUniversitarioExpedido { get; set; }

		public string AntecedentesAcademicos { get; set; }

		public string AntecedentesLaborales { get; set; }

		public DateTime? FechaRecepcion { get; set; }

		public int? UsuarioRecepcion { get; set; }

		public string Token { get; set; }

        public int? CodigoDNI { get; set; }
        public int? Adjunto1 { get; set; }
        public int? Adjunto2 { get; set; }
        public int? Adjunto3 { get; set; }
		#endregion

	}
}
