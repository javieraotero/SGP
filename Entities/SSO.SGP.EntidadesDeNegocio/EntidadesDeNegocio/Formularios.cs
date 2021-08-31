
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
	[MetadataTypeAttribute(typeof(FormulariosMetaData))]
	[Table("Formularios")]
	public partial class Formularios
	{
		#region Constructor
		public Formularios()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Nombre")]
		[StringLength(50, ErrorMessage ="Nombre no puede superar los 50 caracteres")]
		public string Nombre { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		[StringLength(255, ErrorMessage ="Descripcion no puede superar los 255 caracteres")]
		public string Descripcion { get; set; }

		[StringLength(255, ErrorMessage ="Url no puede superar los 255 caracteres")]
		public string Url { get; set; }

		//public virtual ICollection<FormulariosModulosRel> FormulariosModulosRel { get; set; }

		public virtual ICollection<ItemsMenu> ItemsMenu { get; set; }

		public virtual ICollection<Permisos> Permisos { get; set; }
		#endregion

	}
}
