
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
	[MetadataTypeAttribute(typeof(RolesPersonaadmRefMetaData))]
	[Table("RolesPersonaadmRef")]
	public partial class RolesPersonaadmRef
	{
		#region Constructor
		public RolesPersonaadmRef()
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

		[Required(ErrorMessage = "Debe ingresar Funcionario")]
		public bool Funcionario { get; set; }

		[Required(ErrorMessage = "Debe ingresar EsUsuarioSistema")]
		public bool EsUsuarioSistema { get; set; }

		public virtual ICollection<ExpedientesPersonaadm> ExpedientesPersonaadm { get; set; }
		#endregion

	}
}
