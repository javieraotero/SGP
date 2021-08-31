
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
	[MetadataTypeAttribute(typeof(AudienciasAnterioresMetaData))]
	[Table("AudienciasAnteriores")]
	public partial class AudienciasAnteriores
	{
		#region Constructor
		public AudienciasAnteriores()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaDesde")]
		public DateTime FechaDesde { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaHasta")]
		public DateTime FechaHasta { get; set; }

		[Required(ErrorMessage = "Debe ingresar DiaDesde")]
		public int DiaDesde { get; set; }

		[Required(ErrorMessage = "Debe ingresar MesDesde")]
		public int MesDesde { get; set; }

		[Required(ErrorMessage = "Debe ingresar AnioDesde")]
		public int AnioDesde { get; set; }

		[Required(ErrorMessage = "Debe ingresar DiaHasta")]
		public int DiaHasta { get; set; }

		[Required(ErrorMessage = "Debe ingresar MesHasta")]
		public int MesHasta { get; set; }

		[Required(ErrorMessage = "Debe ingresar AnioHasta")]
		public int AnioHasta { get; set; }

		[Required(ErrorMessage = "Debe ingresar Agente")]
		public int Agente { get; set; }

		[StringLength(255, ErrorMessage ="Descripcion no puede superar los 255 caracteres")]
		public string Descripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activa")]
		public bool Activa { get; set; }

		public DateTime? FechaAlta { get; set; }

		public DateTime? FechaModificacion { get; set; }

		public DateTime? FechaEliminacion { get; set; }

		[ForeignKey("Agente")]
		public virtual Usuarios Agentes { get; set; }
		#endregion

	}
}
