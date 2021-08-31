
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
	[MetadataTypeAttribute(typeof(GruposUsuarioRefMetaData))]
	[Table("GruposUsuarioRef")]
	public partial class GruposUsuarioRef
	{
		#region Constructor
		public GruposUsuarioRef()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		[StringLength(60, ErrorMessage ="Descripcion no puede superar los 60 caracteres")]
		public string Descripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar EsPolicia")]
		public bool EsPolicia { get; set; }

        //public virtual ICollection<ItemsMenuGruposUsuarioRel> ItemsMenuGruposUsuarioRel { get; set; }

        //public virtual ICollection<PermisosGruposUsuarioRel> PermisosGruposUsuarioRel { get; set; }

		//public virtual ICollection<Usuarios> Usuarios { get; set; }

		public virtual ICollection<UsuariosOrganismosGrupos> UsuariosOrganismosGrupos { get; set; }
		#endregion

	}
}
