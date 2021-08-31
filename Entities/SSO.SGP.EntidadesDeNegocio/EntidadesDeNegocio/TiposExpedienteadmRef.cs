
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
	[MetadataTypeAttribute(typeof(TiposExpedienteadmRefMetaData))]
	[Table("TiposExpedienteadmRef")]
	public partial class TiposExpedienteadmRef
	{
		#region Constructor
		public TiposExpedienteadmRef()
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

		[Required(ErrorMessage = "Debe ingresar UltimoNumero")]
		public int UltimoNumero { get; set; }

		//public virtual ICollection<Expedientesadm> Expedientesadm { get; set; }
		#endregion

	}
}
