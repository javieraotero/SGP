
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
	[MetadataTypeAttribute(typeof(PermisosGruposUsuarioRelMetaData))]
	[Table("PermisosGruposUsuarioRel")]
	public partial class PermisosGruposUsuarioRel
	{
		#region Constructor
		public PermisosGruposUsuarioRel()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Permiso { get; set; }

		[Key]
		public int GrupoUsuario { get; set; }

		[ForeignKey("Permiso")]
		public virtual Permisos Permisos { get; set; }

		[ForeignKey("GrupoUsuario")]
		public virtual GruposUsuarioRef GrupoUsuarios { get; set; }
		#endregion

	}
}
