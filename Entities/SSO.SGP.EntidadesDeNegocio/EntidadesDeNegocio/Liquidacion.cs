
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
	[MetadataTypeAttribute(typeof(LiquidacionMetaData))]
	[Table("Liquidacion")]
	public partial class Liquidacion
	{
		#region Constructor
		public Liquidacion()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Causa")]
		public int Causa { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaLiq")]
		public DateTime FechaLiq { get; set; }

		[Required(ErrorMessage = "Debe ingresar CapitalTotal")]
		public decimal CapitalTotal { get; set; }

		[Required(ErrorMessage = "Debe ingresar InteresTotal")]
		public decimal InteresTotal { get; set; }

		[Required(ErrorMessage = "Debe ingresar InteresAplicado")]
		public decimal InteresAplicado { get; set; }

		[Required(ErrorMessage = "Debe ingresar TipoHonorario")]
		[StringLength(2, ErrorMessage ="TipoHonorario no puede superar los 2 caracteres")]
		public string TipoHonorario { get; set; }

		[Required(ErrorMessage = "Debe ingresar IVA")]
		public bool IVA { get; set; }

		[Required(ErrorMessage = "Debe ingresar Capitaliza")]
		public bool Capitaliza { get; set; }

		[Required(ErrorMessage = "Debe ingresar HonorariosTotal")]
		public decimal HonorariosTotal { get; set; }

		[Required(ErrorMessage = "Debe ingresar GastosTotal")]
		public decimal GastosTotal { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activo")]
		public bool Activo { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioAlta")]
		public int UsuarioAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar IVAIntereses")]
		public bool IVAIntereses { get; set; }

		public virtual ICollection<LiquidacionAbogados> LiquidacionAbogados104DE43E { get; set; }

		public virtual ICollection<LiquidacionCapitales> LiquidacionCapitales06C47A04 { get; set; }

		public virtual ICollection<LiquidacionConfiguracionValores> LiquidacionConfiguracionValores1606BD94 { get; set; }

		public virtual ICollection<LiquidacionGastos> LiquidacionGastos0B892F21 { get; set; }

		[ForeignKey("Causa")]
		public virtual Causas Causas { get; set; }

		[ForeignKey("UsuarioAlta")]
		public virtual Usuarios UsuarioAltas { get; set; }
		#endregion

	}
}
