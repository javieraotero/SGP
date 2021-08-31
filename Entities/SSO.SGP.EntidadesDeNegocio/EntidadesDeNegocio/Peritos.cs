
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
	[MetadataTypeAttribute(typeof(PeritosMetaData))]
	[Table("Peritos")]
	public partial class Peritos
	{
		#region Constructor
		public Peritos()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[StringLength(200, ErrorMessage ="Universidad no puede superar los 200 caracteres")]
		public string Universidad { get; set; }

		public DateTime? FechaTitulo { get; set; }

		public bool? EstaSuspendido { get; set; }

		public DateTime? SuspendidoDesde { get; set; }

		public DateTime? SuspendidoHasta { get; set; }

		[StringLength(255, ErrorMessage ="Observaciones no puede superar los 255 caracteres")]
		public string Observaciones { get; set; }

		[StringLength(255, ErrorMessage ="Sanciones no puede superar los 255 caracteres")]
		public string Sanciones { get; set; }

		public int? Persona { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activo")]
		public bool Activo { get; set; }

		public virtual ICollection<PeritosInscripcion> PeritosInscripcion { get; set; }

		public virtual ICollection<PeritosSanciones> PeritosSanciones { get; set; }

		[ForeignKey("Persona")]
		public virtual Personas Personas { get; set; }
		#endregion

	}
}
