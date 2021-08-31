
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
	[MetadataTypeAttribute(typeof(UsuariosOrganismosGruposMetaData))]
	[Table("UsuariosOrganismosGrupos")]
	public partial class UsuariosOrganismosGrupos
	{
		#region Constructor
		public UsuariosOrganismosGrupos()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Usuario")]
		public int Usuario { get; set; }

		[Required(ErrorMessage = "Debe ingresar Organismo")]
		public int Organismo { get; set; }

		[Required(ErrorMessage = "Debe ingresar GrupoUsuario")]
		public int GrupoUsuario { get; set; }

		[ForeignKey("Usuario")]
		public virtual Usuarios Usuarios { get; set; }

		[ForeignKey("Organismo")]
		public virtual OrganismosRef Organismos { get; set; }

		[ForeignKey("GrupoUsuario")]
		public virtual GruposUsuarioRef GrupoUsuarios { get; set; }
		#endregion

	}
}
