
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
	[MetadataTypeAttribute(typeof(PresupuestacionMetaData))]
	[Table("Presupuestacion")]
	public partial class Presupuestacion
	{
		#region Constructor
		public Presupuestacion()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Causa")]
		public int Causa { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaPresu")]
		public DateTime FechaPresu { get; set; }

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

		[Required(ErrorMessage = "Debe ingresar FechaInicioEjecutivo")]
		public DateTime FechaInicioEjecutivo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activo")]
		public bool Activo { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioAlta")]
		public int UsuarioAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar IVAIntereses")]
		public bool IVAIntereses { get; set; }

		public virtual ICollection<PresupuestacionCapitales> PresupuestacionCapitales2C2B08DD { get; set; }

		public virtual ICollection<PresupuestacionConfiguracionValores> PresupuestacionConfiguracionValores3A792834 { get; set; }

		public virtual ICollection<PresupuestacionGastos> PresupuestacionGastos30EFBDFA { get; set; }

		[ForeignKey("Causa")]
		public virtual Causas Causas { get; set; }

		[ForeignKey("UsuarioAlta")]
		public virtual Usuarios UsuarioAltas { get; set; }
		#endregion

	}
}
