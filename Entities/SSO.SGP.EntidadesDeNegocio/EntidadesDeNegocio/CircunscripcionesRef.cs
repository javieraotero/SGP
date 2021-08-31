
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
	[MetadataTypeAttribute(typeof(CircunscripcionesRefMetaData))]
	[Table("CircunscripcionesRef")]
	public partial class CircunscripcionesRef
	{
		#region Constructor
		public CircunscripcionesRef()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		[StringLength(50, ErrorMessage ="Descripcion no puede superar los 50 caracteres")]
		public string Descripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Abreviatura")]
		[StringLength(5, ErrorMessage ="Abreviatura no puede superar los 5 caracteres")]
		public string Abreviatura { get; set; }

		[Required(ErrorMessage = "Debe ingresar UltimoExpediente")]
		public int UltimoExpediente { get; set; }

		[Required(ErrorMessage = "Debe ingresar CircunscripcionOJ")]
		public int CircunscripcionOJ { get; set; }

		[Required(ErrorMessage = "Debe ingresar UltimaNotificacion")]
		public int UltimaNotificacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar ReceptoriaSorteaCausa")]
		public bool ReceptoriaSorteaCausa { get; set; }

		[Required(ErrorMessage = "Debe ingresar MediacionCivil")]
		public bool MediacionCivil { get; set; }

		[Required(ErrorMessage = "Debe ingresar CircunscripcionArchiva")]
		public int CircunscripcionArchiva { get; set; }

		[Required(ErrorMessage = "Debe ingresar NotificaPolicia")]
		public bool NotificaPolicia { get; set; }

		[Required(ErrorMessage = "Debe ingresar ReceptoriaUnica")]
		public bool ReceptoriaUnica { get; set; }

		//public virtual ICollection<Acumulados> Acumulados { get; set; }

		//public virtual ICollection<ArchivoExpediente> ArchivoExpediente { get; set; }

		//public virtual ICollection<Audiencias> Audiencias { get; set; }

		//public virtual ICollection<AudienciasCivil> AudienciasCivil { get; set; }

		//public virtual ICollection<AudienciasSolicitud> AudienciasSolicitud { get; set; }

		//public virtual ICollection<CategoriasCausasCivil> CategoriasCausasCivil { get; set; }

		//public virtual ICollection<CategoriasExpedientes> CategoriasExpedientes { get; set; }

		//public virtual ICollection<Causas> Causas { get; set; }
		#endregion

	}
}
