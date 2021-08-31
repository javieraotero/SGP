
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
	[MetadataTypeAttribute(typeof(AuditoriaMetaData))]
	[Table("Auditoria")]
	public partial class Auditoria
	{
		#region Constructor
		public Auditoria()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Tabla")]
		[StringLength(50, ErrorMessage ="Tabla no puede superar los 50 caracteres")]
		public string Tabla { get; set; }

		[Required(ErrorMessage = "Debe ingresar Columna")]
		[StringLength(50, ErrorMessage ="Columna no puede superar los 50 caracteres")]
		public string Columna { get; set; }

		[StringLength(50, ErrorMessage ="Referencia no puede superar los 50 caracteres")]
		public string Referencia { get; set; }

		public int? IdReferencia { get; set; }

		[Required(ErrorMessage = "Debe ingresar Usuario")]
		public int Usuario { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fecha")]
		public DateTime Fecha { get; set; }

		[Required(ErrorMessage = "Debe ingresar ValorAnterior")]
		[StringLength(1000, ErrorMessage ="ValorAnterior no puede superar los 1000 caracteres")]
		public string ValorAnterior { get; set; }

		[Required(ErrorMessage = "Debe ingresar ValorNuevo")]
		[StringLength(1000, ErrorMessage ="ValorNuevo no puede superar los 1000 caracteres")]
		public string ValorNuevo { get; set; }
		#endregion

	}
}
