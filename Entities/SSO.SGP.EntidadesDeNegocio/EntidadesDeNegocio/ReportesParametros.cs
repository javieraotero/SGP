
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
	[MetadataTypeAttribute(typeof(ReportesParametrosMetaData))]
	[Table("ReportesParametros")]
	public partial class ReportesParametros
	{
		#region Constructor
		public ReportesParametros()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Nombre")]
		[StringLength(50, ErrorMessage ="Nombre no puede superar los 50 caracteres")]
		public string Nombre { get; set; }

		[StringLength(50, ErrorMessage ="Valor no puede superar los 50 caracteres")]
		public string ValorPorDefecto { get; set; }

		[Required(ErrorMessage = "Debe ingresar Reporte")]
		public int Reporte { get; set; }

        public bool Obligatorio { get; set; }

		[ForeignKey("Reporte")]
		public virtual Reportes Reportes { get; set; }
		#endregion

	}
}
