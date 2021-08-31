
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
	[MetadataTypeAttribute(typeof(ReservaSalasAudienciaMetaData))]
	[Table("ReservaSalasAudiencia")]
	public partial class ReservaSalasAudiencia
	{
		#region Constructor
		public ReservaSalasAudiencia()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Sala")]
		public int Sala { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		[StringLength(250, ErrorMessage ="Descripcion no puede superar los 250 caracteres")]
		public string Descripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaDesde")]
		public DateTime FechaDesde { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaHasta")]
		public DateTime FechaHasta { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activa")]
		public bool Activa { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioAlta")]
		public int UsuarioAlta { get; set; }

		public DateTime? FechaModificacion { get; set; }

		public int? UsuarioModificacion { get; set; }

		[ForeignKey("Sala")]
		public virtual OrganismosRef Salas { get; set; }
		#endregion

	}
}
