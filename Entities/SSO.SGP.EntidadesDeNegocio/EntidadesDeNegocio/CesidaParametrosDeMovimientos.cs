
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
	[MetadataTypeAttribute(typeof(CesidaParametrosDeMovimientosMetaData))]
	[Table("CesidaParametrosDeMovimientos")]
	public partial class CesidaParametrosDeMovimientos
	{
		#region Constructor
		public CesidaParametrosDeMovimientos()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		public string Descripcion { get; set; }

		public int? TipoDeDato { get; set; }

		[Required(ErrorMessage = "Debe ingresar Obligatorio")]
		public bool Obligatorio { get; set; }

		public string Referencia { get; set; }

		public string Predeterminado { get; set; }

        public int Movimiento { get; set; }

        public string Etiqueta { get; set; }

        public string Hint { get; set; }

        public int OrdenPantalla { get; set; }

		#endregion

	}
}
