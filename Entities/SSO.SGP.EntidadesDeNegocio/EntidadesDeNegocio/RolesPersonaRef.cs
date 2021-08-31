
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
	[MetadataTypeAttribute(typeof(RolesPersonaRefMetaData))]
	[Table("RolesPersonaRef")]
	public partial class RolesPersonaRef
	{
		#region Constructor
		public RolesPersonaRef()
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

		[Required(ErrorMessage = "Debe ingresar NotificaAutoAudiencia")]
		public bool NotificaAutoAudiencia { get; set; }

		[Required(ErrorMessage = "Debe ingresar EsUsuarioSistema")]
		public bool EsUsuarioSistema { get; set; }

		public virtual ICollection<ExpedientesPersona> ExpedientesPersona { get; set; }

		public virtual ICollection<PreventivosPersona> PreventivosPersona { get; set; }
		#endregion

	}
}
