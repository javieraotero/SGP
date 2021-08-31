
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
	[MetadataTypeAttribute(typeof(ProtocolosMetaData))]
	[Table("Protocolos")]
	public partial class Protocolos
	{
		#region Constructor
		public Protocolos()
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

		[Required(ErrorMessage = "Debe ingresar RequiereVoces")]
		public bool RequiereVoces { get; set; }

		[Required(ErrorMessage = "Debe ingresar Ambito")]
		public int Ambito { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activo")]
		public bool Activo { get; set; }

		public virtual ICollection<Actuaciones> ActuacionesProtocolo { get; set; }

		[ForeignKey("Ambito")]
		public virtual Ambitos Ambitos { get; set; }
		#endregion

	}
}
