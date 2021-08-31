
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
	[MetadataTypeAttribute(typeof(FuerosRefMetaData))]
	[Table("FuerosRef")]
	public partial class FuerosRef
	{
		#region Constructor
		public FuerosRef()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		[StringLength(20, ErrorMessage ="Descripcion no puede superar los 20 caracteres")]
		public string Descripcion { get; set; }

		//public virtual ICollection<Ambitos> Ambitos { get; set; }

		//public virtual ICollection<ArchivoExpediente> ArchivoExpediente { get; set; }
		#endregion

	}
}
