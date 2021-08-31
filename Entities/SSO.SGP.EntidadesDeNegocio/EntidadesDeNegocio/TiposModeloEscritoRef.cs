
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
	[MetadataTypeAttribute(typeof(TiposModeloEscritoRefMetaData))]
	[Table("TiposModeloEscritoRef")]
	public partial class TiposModeloEscritoRef
	{
		#region Constructor
		public TiposModeloEscritoRef()
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

		public int? TipoPadre { get; set; }

		public virtual ICollection<ModelosEscrito> ModelosEscrito { get; set; }

		public virtual ICollection<TiposModeloEscritoRef> TiposModeloEscritoRef1 { get; set; }
		#endregion

	}
}
