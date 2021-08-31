
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
	[MetadataTypeAttribute(typeof(SustitucionesMetaData))]
	[Table("Sustituciones")]
	public partial class Sustituciones
	{
		#region Constructor
		public Sustituciones()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Agente")]
		public int Agente { get; set; }

		[StringLength(50, ErrorMessage ="Acuerdo no puede superar los 50 caracteres")]
		public string Acuerdo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Desde")]
		public DateTime Desde { get; set; }

		public DateTime? Hasta { get; set; }

		[Required(ErrorMessage = "Debe ingresar Motivo")]
		public int Motivo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Cargo")]
		public int Cargo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Organismo")]
		public int Organismo { get; set; }

		[ForeignKey("Agente")]
		public virtual Agentes Agentes { get; set; }

		[ForeignKey("Cargo")]
		public virtual CargosRef Cargos { get; set; }

		[ForeignKey("Organismo")]
		public virtual OrganismosRef Organismoss { get; set; }

        public DateTime? FechaElimina { get; set; }

		#endregion

	}
}
