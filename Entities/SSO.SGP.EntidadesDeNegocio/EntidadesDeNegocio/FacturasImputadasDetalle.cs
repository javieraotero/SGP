
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SSO.SGP.MetaData;
using System.Web.Script.Serialization;

namespace SSO.SGP.EntidadesDeNegocio
{
	/// <summary>
	/// Entidad Generada por el Generador de codigo.
	/// </summary>
	[MetadataTypeAttribute(typeof(FacturasImputadasDetalleMetaData))]
	[Table("FacturasImputadasDetalle")]
	public partial class FacturasImputadasDetalle
	{
		#region Constructor
		public FacturasImputadasDetalle()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar FacturaImputada")]
		public int FacturaImputada { get; set; }

		[Required(ErrorMessage = "Debe ingresar Partida")]
		public int Partida { get; set; }

		[Required(ErrorMessage = "Debe ingresar Division")]
		public int Division { get; set; }

		[Required(ErrorMessage = "Debe ingresar Importe")]
		public decimal Importe { get; set; }

		[ForeignKey("FacturaImputada")] 
        [ScriptIgnore]
		public virtual FacturasImputadas FacturaImputadas { get; set; }

		[ForeignKey("Partida")]
		public virtual PartidasPresupuestarias Partidas { get; set; }

		[ForeignKey("Division")]
		public virtual DivisionesExtraPresupuestarias Divisions { get; set; }
		#endregion

	}
}
