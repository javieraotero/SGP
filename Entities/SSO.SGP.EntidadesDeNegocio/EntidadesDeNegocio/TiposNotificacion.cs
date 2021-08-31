
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
	[MetadataTypeAttribute(typeof(TiposNotificacionMetaData))]
	[Table("TiposNotificacion")]
	public partial class TiposNotificacion
	{
		#region Constructor
		public TiposNotificacion()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		[StringLength(150, ErrorMessage ="Descripcion no puede superar los 150 caracteres")]
		public string Descripcion { get; set; }

		public virtual ICollection<Notificaciones> Notificaciones { get; set; }

		public virtual ICollection<NotificacionesCivil> NotificacionesCivil { get; set; }
		#endregion

	}
}
