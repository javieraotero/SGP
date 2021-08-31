
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
	[MetadataTypeAttribute(typeof(UnidadesDeOrganizacionRefMetaData))]
	[Table("UnidadesDeOrganizacionRef")]
	public partial class UnidadesDeOrganizacionRef
	{
		#region Constructor
		public UnidadesDeOrganizacionRef()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Nombre")]
		[StringLength(50, ErrorMessage ="Nombre no puede superar los 50 caracteres")]
		public string Nombre { get; set; }

		//public virtual ICollection<PartidasPresupuestarias> PartidasPresupuestarias { get; set; }
		#endregion

	}
}
