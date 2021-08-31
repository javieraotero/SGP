
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
	[MetadataTypeAttribute(typeof(TiposAudienciaRefMetaData))]
	[Table("TiposAudienciaRef")]
	public partial class TiposAudienciaRef
	{
		#region Constructor
		public TiposAudienciaRef()
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

		[Required(ErrorMessage = "Debe ingresar EnUso")]
		public bool EnUso { get; set; }

		[Required(ErrorMessage = "Debe ingresar Juicio")]
		public bool Juicio { get; set; }

		[Required(ErrorMessage = "Debe ingresar RelevarControl")]
		public int RelevarControl { get; set; }

		[Required(ErrorMessage = "Debe ingresar Ambito")]
		public int Ambito { get; set; }

		[Required(ErrorMessage = "Debe ingresar NotificaPresidenteAudiencia")]
		public bool NotificaPresidenteAudiencia { get; set; }

		public virtual ICollection<Audiencias> Audiencias { get; set; }

		public virtual ICollection<AudienciasSolicitud> AudienciasSolicitud { get; set; }

		public virtual ICollection<TiposActuacionRef> TiposActuacionRef { get; set; }

		[ForeignKey("RelevarControl")]
		public virtual TiposRelevarControl RelevarControls { get; set; }

		[ForeignKey("Ambito")]
		public virtual Ambitos Ambitos { get; set; }
		#endregion

	}
}
