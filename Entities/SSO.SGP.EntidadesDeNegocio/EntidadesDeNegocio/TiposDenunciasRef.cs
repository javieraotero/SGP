
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
	[MetadataTypeAttribute(typeof(TiposDenunciasRefMetaData))]
	[Table("TiposDenunciasRef")]
	public partial class TiposDenunciasRef
	{
		#region Constructor
		public TiposDenunciasRef()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		[StringLength(100, ErrorMessage ="Descripcion no puede superar los 100 caracteres")]
		public string Descripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Modelo")]
		public int Modelo { get; set; }

		public virtual ICollection<Denuncias> Denuncias { get; set; }

		[ForeignKey("Modelo")]
		public virtual ModelosEscrito Modelos { get; set; }
		#endregion

	}
}
