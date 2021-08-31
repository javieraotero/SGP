
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
	[MetadataTypeAttribute(typeof(ProvinciasRefMetaData))]
	[Table("ProvinciasRef")]
	public partial class ProvinciasRef
	{
		#region Constructor
		public ProvinciasRef()
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

		//public virtual ICollection<Causas> Causas { get; set; }

		//public virtual ICollection<Conexiones> Conexiones { get; set; }

		//public virtual ICollection<LocalidadesRef> LocalidadesRef { get; set; }

		//public virtual ICollection<PresentacionesCausa> PresentacionesCausa { get; set; }

		//public virtual ICollection<PresentacionesCausaConexion> PresentacionesCausaConexion { get; set; }
		#endregion

	}
}
