
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
	[MetadataTypeAttribute(typeof(MotivosCancelacionRefMetaData))]
	[Table("MotivosCancelacionRef")]
	public partial class MotivosCancelacionRef
	{
		#region Constructor
		public MotivosCancelacionRef()
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

		public virtual ICollection<Audiencias> Audiencias { get; set; }

		public virtual ICollection<AudienciasEstados> AudienciasEstados { get; set; }
		#endregion

	}
}
