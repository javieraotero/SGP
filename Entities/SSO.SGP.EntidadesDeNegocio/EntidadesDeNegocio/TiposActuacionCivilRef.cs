
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
	[MetadataTypeAttribute(typeof(TiposActuacionCivilRefMetaData))]
	[Table("TiposActuacionCivilRef")]
	public partial class TiposActuacionCivilRef
	{
		#region Constructor
		public TiposActuacionCivilRef()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		[StringLength(100, ErrorMessage ="Descripcion no puede superar los 100 caracteres")]
		public string Descripcion { get; set; }

		public int? EstadoCausa { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activa")]
		public bool Activa { get; set; }

		[Required(ErrorMessage = "Debe ingresar Grupo")]
		public int Grupo { get; set; }

		[Required(ErrorMessage = "Debe ingresar CambiaEtapa")]
		public bool CambiaEtapa { get; set; }

		[Required(ErrorMessage = "Debe ingresar Plazo")]
		public int Plazo { get; set; }

		[Required(ErrorMessage = "Debe ingresar RequiereNotificacion")]
		public bool RequiereNotificacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar RequiereCargo")]
		public bool RequiereCargo { get; set; }

		public int? SubAmbitoCargo { get; set; }

		[Required(ErrorMessage = "Debe ingresar CantidadFirmantes")]
		public int CantidadFirmantes { get; set; }

		[Required(ErrorMessage = "Debe ingresar ModalidadDiasFechaPlazo")]
		public int ModalidadDiasFechaPlazo { get; set; }

		public int? UsuarioAlta { get; set; }

		public DateTime? FechaAlta { get; set; }

		public int? UsuarioModifica { get; set; }

		public DateTime? FechaModifica { get; set; }

		public int? UsuarioElimina { get; set; }

		public DateTime? FechaElimina { get; set; }

		public virtual ICollection<ActuacionesCivil> ActuacionesCivil { get; set; }

		[ForeignKey("EstadoCausa")]
		public virtual EstadosCausaRef EstadoCausas { get; set; }

		[ForeignKey("Grupo")]
		public virtual GruposTipoActuacionCivilRef Grupos { get; set; }

		[ForeignKey("SubAmbitoCargo")]
		public virtual Ambitos SubAmbitoCargos { get; set; }
		#endregion

	}
}
