
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
	[MetadataTypeAttribute(typeof(TiposActuacionadmRefMetaData))]
	[Table("TiposActuacionadmRef")]
	public partial class TiposActuacionadmRef
	{
		#region Constructor
		public TiposActuacionadmRef()
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

		[Required(ErrorMessage = "Debe ingresar Activa")]
		public bool Activa { get; set; }

		[Required(ErrorMessage = "Debe ingresar RequiereCargo")]
		public bool RequiereCargo { get; set; }

		public int? SubAmbitoCargo { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioAlta")]
		public int UsuarioAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

		public int? UsuarioModifica { get; set; }

		public DateTime? FechaModifica { get; set; }

		public int? UsuarioElimina { get; set; }

		public DateTime? FechaElimina { get; set; }

		public int? CantidadFirmantes { get; set; }

        public int? Organismo { get; set; }

		//public virtual ICollection<Actuacionesadm> Actuacionesadm { get; set; }
		#endregion

	}
}
