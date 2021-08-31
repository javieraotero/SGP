
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
	[MetadataTypeAttribute(typeof(TiposOrigenExpedienteRefMetaData))]
	[Table("TiposOrigenExpedienteRef")]
	public partial class TiposOrigenExpedienteRef
	{
		#region Constructor
		public TiposOrigenExpedienteRef()
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

		[Required(ErrorMessage = "Debe ingresar MostrarEnCaratula")]
		public bool MostrarEnCaratula { get; set; }

		[Required(ErrorMessage = "Debe ingresar MostrarEnOficinaJudicial")]
		public bool MostrarEnOficinaJudicial { get; set; }

		[Required(ErrorMessage = "Debe ingresar TipoActuacionInicio")]
		public int TipoActuacionInicio { get; set; }

		[Required(ErrorMessage = "Debe ingresar RequiereFiscal")]
		public bool RequiereFiscal { get; set; }

		[Required(ErrorMessage = "Debe ingresar RequiereJuez")]
		public bool RequiereJuez { get; set; }

		[Required(ErrorMessage = "Debe ingresar RequiereDefensor")]
		public bool RequiereDefensor { get; set; }

		public virtual ICollection<Expedientes> Expedientes { get; set; }

		[ForeignKey("TipoActuacionInicio")]
		public virtual TiposActuacionRef TipoActuacionInicios { get; set; }
		#endregion

	}
}
