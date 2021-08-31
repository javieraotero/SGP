
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
	[MetadataTypeAttribute(typeof(PeritosSancionesMetaData))]
	[Table("PeritosSanciones")]
	public partial class PeritosSanciones
	{
		#region Constructor
		public PeritosSanciones()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Perito")]
		public int Perito { get; set; }

		[Required(ErrorMessage = "Debe ingresar SuspendidoDesde")]
		public DateTime SuspendidoDesde { get; set; }

		[Required(ErrorMessage = "Debe ingresar SuspendidoHasta")]
		public DateTime SuspendidoHasta { get; set; }

		[StringLength(255, ErrorMessage ="Sanciones no puede superar los 255 caracteres")]
		public string Sanciones { get; set; }

		[ForeignKey("Perito")]
		public virtual Peritos Peritos { get; set; }
		#endregion

	}
}
