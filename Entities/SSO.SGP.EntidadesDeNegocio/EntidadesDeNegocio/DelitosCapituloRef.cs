
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
	[MetadataTypeAttribute(typeof(DelitosCapituloRefMetaData))]
	[Table("DelitosCapituloRef")]
	public partial class DelitosCapituloRef
	{
		#region Constructor
		public DelitosCapituloRef()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		[StringLength(255, ErrorMessage ="Descripcion no puede superar los 255 caracteres")]
		public string Descripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Titulo")]
		public int Titulo { get; set; }

		public virtual ICollection<DelitosRef> DelitosRef { get; set; }

		[ForeignKey("Titulo")]
		public virtual DelitosTituloRef Titulos { get; set; }
		#endregion

	}
}
