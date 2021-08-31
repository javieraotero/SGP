
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
	[MetadataTypeAttribute(typeof(EjecucionesPresupuestariasReestructurasMetaData))]
	[Table("EjecucionesPresupuestariasReestructuras")]
	public partial class EjecucionesPresupuestariasReestructuras
	{
		#region Constructor
		public EjecucionesPresupuestariasReestructuras()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Anio")]
		public int Anio { get; set; }

		[Required(ErrorMessage = "Debe ingresar PartidaPresupuestaria")]
		public int PartidaPresupuestaria { get; set; }

		[Required(ErrorMessage = "Debe ingresar Importe")]
		public decimal Importe { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fecha")]
		public DateTime Fecha { get; set; }

		[Required(ErrorMessage = "Debe ingresar Observaciones")]
		public string Observaciones { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioAlta")]
		public int UsuarioAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

        public decimal? ImporteOtorgado { get; set; }

        public DateTime? FechaOtorgado { get; set; }

        public int? Tipo { get; set; }
        #endregion

    }
}
