
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
	[MetadataTypeAttribute(typeof(BienesEliminadosMetaData))]
	[Table("BienesEliminados")]
	public partial class BienesEliminados
	{
		#region Constructor
		public BienesEliminados()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar NumeroDeInventario")]
		public int NumeroDeInventario { get; set; }

		[Required(ErrorMessage = "Debe ingresar Usuario")]
		public int Usuario { get; set; }

		[Required(ErrorMessage = "Debe ingresar Nombre")]
		public string Nombre { get; set; }

		[Required(ErrorMessage = "Debe ingresar Organizacion")]
		public int Organizacion { get; set; }

		public int? Primario { get; set; }

		public int? Secundario { get; set; }

		public int? Uso { get; set; }

		[Required(ErrorMessage = "Debe ingresar Causa")]
		public string Causa { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fecha")]
		public DateTime Fecha { get; set; }
		#endregion

	}
}
