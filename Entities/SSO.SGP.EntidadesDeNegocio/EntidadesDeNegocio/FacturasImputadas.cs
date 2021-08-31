
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SSO.SGP.MetaData;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace SSO.SGP.EntidadesDeNegocio
{
	/// <summary>
	/// Entidad Generada por el Generador de codigo.
	/// </summary>
	[MetadataTypeAttribute(typeof(FacturasImputadasMetaData))]
	[Table("FacturasImputadas")]
	public partial class FacturasImputadas
	{
		#region Constructor
		public FacturasImputadas()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Factura")]
		public int Factura { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fecha")]
		public DateTime Fecha { get; set; }

		[Required(ErrorMessage = "Debe ingresar AnioContable")]
		public int AnioContable { get; set; }

		[Required(ErrorMessage = "Debe ingresar Usuario")]
		public int Usuario { get; set; }

		public DateTime? FechaElimina { get; set; }

		public int? UsuarioElimina { get; set; }

		public virtual ICollection<FacturasImputadasDetalle> FacturasImputadasDetalle { get; set; }

        [ForeignKey("Factura")]
        [ScriptIgnore]
        public virtual Facturas Facturas { get; set; }
        #endregion

    }
}
