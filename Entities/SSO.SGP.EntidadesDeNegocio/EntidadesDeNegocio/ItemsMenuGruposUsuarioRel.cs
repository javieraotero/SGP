
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
	[MetadataTypeAttribute(typeof(ItemsMenuGruposUsuarioRelMetaData))]
	[Table("ItemsMenuGruposUsuarioRel")]
	public partial class ItemsMenuGruposUsuarioRel
	{
		#region Constructor
		public ItemsMenuGruposUsuarioRel()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int ItemMenu { get; set; }

		[Key]
		public int GrupoUsuario { get; set; }

		[ForeignKey("ItemMenu")]
		public virtual ItemsMenu ItemMenus { get; set; }

		[ForeignKey("GrupoUsuario")]
		public virtual GruposUsuarioRef GrupoUsuarios { get; set; }
		#endregion

	}
}
