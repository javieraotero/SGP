
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
	[MetadataTypeAttribute(typeof(TiposDatoRefMetaData))]
	[Table("TiposDatoRef")]
	public partial class TiposDatoRef
	{
		#region Constructor
		public TiposDatoRef()
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

		[StringLength(50, ErrorMessage ="Mascara no puede superar los 50 caracteres")]
		public string Mascara { get; set; }

		public virtual ICollection<Columnas> Columnas { get; set; }
		#endregion

	}
}
