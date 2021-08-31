
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
	[MetadataTypeAttribute(typeof(PreventivosElementosMetaData))]
	[Table("PreventivosElementos")]
	public partial class PreventivosElementos
	{
		#region Constructor
		public PreventivosElementos()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Preventivo")]
		public int Preventivo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Rol")]
		public int Rol { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		[StringLength(2147483647, ErrorMessage ="Descripcion no puede superar los 2147483647 caracteres")]
		public string Descripcion { get; set; }

		public int? GrupoElemento { get; set; }

		[ForeignKey("Preventivo")]
		public virtual Preventivos Preventivos { get; set; }

		[ForeignKey("Rol")]
		public virtual RolesElementoRef Rols { get; set; }

		[ForeignKey("GrupoElemento")]
		public virtual GrupoElementosPoliciaRef GrupoElementos { get; set; }
		#endregion

	}
}
