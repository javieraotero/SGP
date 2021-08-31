
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
	[MetadataTypeAttribute(typeof(ModulosMetaData))]
	[Table("Modulos")]
	public partial class Modulos
	{
		#region Constructor
		public Modulos()
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

		[Required(ErrorMessage = "Debe ingresar Abreviatura")]
		[StringLength(5, ErrorMessage ="Abreviatura no puede superar los 5 caracteres")]
		public string Abreviatura { get; set; }

		public int? ModuloPadre { get; set; }

        //public virtual ICollection<FormulariosModulosRel> FormulariosModulosRel { get; set; }

		public virtual ICollection<GruposTipoActuacionCivilRef> GruposTipoActuacionCivilRef { get; set; }

		public virtual ICollection<GruposTipoActuacionRef> GruposTipoActuacionRef { get; set; }

		public virtual ICollection<ItemsMenu> ItemsMenu { get; set; }

		public virtual ICollection<Modulos> Moduloss { get; set; }
		#endregion

	}
}
