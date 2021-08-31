
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
	[MetadataTypeAttribute(typeof(MotivosCancelacionCivilRefMetaData))]
	[Table("MotivosCancelacionCivilRef")]
	public partial class MotivosCancelacionCivilRef
	{
		#region Constructor
		public MotivosCancelacionCivilRef()
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

		public virtual ICollection<AudienciasCivil> AudienciasCivil { get; set; }

		public virtual ICollection<AudienciasEstadosCivil> AudienciasEstadosCivil { get; set; }
		#endregion

	}
}
