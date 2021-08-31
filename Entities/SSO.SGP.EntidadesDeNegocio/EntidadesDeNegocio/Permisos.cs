
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
	[MetadataTypeAttribute(typeof(PermisosMetaData))]
	[Table("Permisos")]
	public partial class Permisos
	{
		#region Constructor
		public Permisos()
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

		[Required(ErrorMessage = "Debe ingresar Formulario")]
		public int Formulario { get; set; }

		[Required(ErrorMessage = "Debe ingresar Accion")]
		[StringLength(50, ErrorMessage ="Accion no puede superar los 50 caracteres")]
		public string Accion { get; set; }

        //public virtual ICollection<PermisosGruposUsuarioRel> PermisosGruposUsuarioRel { get; set; }

		[ForeignKey("Formulario")]
		public virtual Formularios Formularios { get; set; }
		#endregion

	}
}
