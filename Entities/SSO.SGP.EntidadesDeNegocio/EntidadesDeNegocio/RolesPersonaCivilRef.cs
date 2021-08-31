
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
	[MetadataTypeAttribute(typeof(RolesPersonaCivilRefMetaData))]
	[Table("RolesPersonaCivilRef")]
	public partial class RolesPersonaCivilRef
	{
		#region Constructor
		public RolesPersonaCivilRef()
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

		[Required(ErrorMessage = "Debe ingresar Tipo")]
		public int Tipo { get; set; }

		[Required(ErrorMessage = "Debe ingresar NotificaAutoAudiencia")]
		public bool NotificaAutoAudiencia { get; set; }

		public virtual ICollection<CausasResponsable> CausasResponsable { get; set; }

		public virtual ICollection<Conexiones> Conexiones { get; set; }

		public virtual ICollection<PresentacionesCausaConexion> PresentacionesCausaConexion { get; set; }
		#endregion

	}
}
