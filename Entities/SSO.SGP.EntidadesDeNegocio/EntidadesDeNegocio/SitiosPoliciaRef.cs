
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
	[MetadataTypeAttribute(typeof(SitiosPoliciaRefMetaData))]
	[Table("SitiosPoliciaRef")]
	public partial class SitiosPoliciaRef
	{
		#region Constructor
		public SitiosPoliciaRef()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar IdSitio")]
		public int IdSitio { get; set; }

		[Required(ErrorMessage = "Debe ingresar Sitio")]
		[StringLength(50, ErrorMessage ="Sitio no puede superar los 50 caracteres")]
		public string Sitio { get; set; }

		public virtual ICollection<Preventivos> Preventivos { get; set; }
		#endregion

	}
}
