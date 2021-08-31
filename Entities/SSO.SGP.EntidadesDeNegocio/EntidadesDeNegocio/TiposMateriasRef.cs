
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
	[MetadataTypeAttribute(typeof(TiposMateriasRefMetaData))]
	[Table("TiposMateriasRef")]
	public partial class TiposMateriasRef
	{
		#region Constructor
		public TiposMateriasRef()
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

		[Required(ErrorMessage = "Debe ingresar Mnemo")]
		[StringLength(1, ErrorMessage ="Mnemo no puede superar los 1 caracteres")]
		public string Mnemo { get; set; }

		public virtual ICollection<Materias> Materias { get; set; }
		#endregion

	}
}
