
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
	[MetadataTypeAttribute(typeof(AgentesBonificacionesMetaData))]
	[Table("AgentesBonificaciones")]
	public partial class AgentesBonificaciones
	{
		#region Constructor
		public AgentesBonificaciones()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Agente")]
		public int Agente { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar Porcentaje")]
		public decimal Porcentaje { get; set; }

		[Required(ErrorMessage = "Debe ingresar Aprobado")]
		public bool Aprobado { get; set; }

		[Required(ErrorMessage = "Debe ingresar Cargo")]
		public int Cargo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Organismo")]
		public int Organismo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Mes")]
		public int Mes { get; set; }

		[Required(ErrorMessage = "Debe ingresar Anio")]
		public int Anio { get; set; }

		[Required(ErrorMessage = "Debe ingresar DiasDeLicencia")]
		public int DiasDeLicencia { get; set; }

		public DateTime? FechaDesde { get; set; }

		public DateTime? FechaHasta { get; set; }

        public bool Aplica { get; set; }

		[ForeignKey("Agente")]
		public virtual Agentes Agentes { get; set; }

		[ForeignKey("Organismo")]
		public virtual OrganismosRef Organismos { get; set; }
		#endregion

	}
}
