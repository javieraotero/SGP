
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
	[MetadataTypeAttribute(typeof(ItemsMenuMetaData))]
	[Table("ItemsMenu")]
	public partial class ItemsMenu
	{
		#region Constructor
		public ItemsMenu()
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

		public int? ItemPadre { get; set; }

		[StringLength(100, ErrorMessage ="Parametros no puede superar los 100 caracteres")]
		public string Parametros { get; set; }

		[StringLength(70, ErrorMessage ="Imagen no puede superar los 70 caracteres")]
		public string Imagen { get; set; }

		[StringLength(20, ErrorMessage ="Tooltip no puede superar los 20 caracteres")]
		public string Tooltip { get; set; }

		[Required(ErrorMessage = "Debe ingresar MostrarEnBarra")]
		public bool MostrarEnBarra { get; set; }

		[Required(ErrorMessage = "Debe ingresar Camino")]
		[StringLength(100, ErrorMessage ="Camino no puede superar los 100 caracteres")]
		public string Camino { get; set; }

		[Required(ErrorMessage = "Debe ingresar Orden")]
		public int Orden { get; set; }

		[Required(ErrorMessage = "Debe ingresar Modulo")]
		public int Modulo { get; set; }

		public int? Formulario { get; set; }

		//public virtual ICollection<ItemsMenuGruposUsuarioRel> ItemsMenuGruposUsuarioRel { get; set; }

		[ForeignKey("Modulo")]
		public virtual Modulos Modulos { get; set; }

		[ForeignKey("Formulario")]
		public virtual Formularios Formularios { get; set; }
		#endregion

	}
}
