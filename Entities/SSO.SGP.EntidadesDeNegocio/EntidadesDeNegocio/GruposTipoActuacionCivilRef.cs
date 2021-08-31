
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
	[MetadataTypeAttribute(typeof(GruposTipoActuacionCivilRefMetaData))]
	[Table("GruposTipoActuacionCivilRef")]
	public partial class GruposTipoActuacionCivilRef
	{
		#region Constructor
		public GruposTipoActuacionCivilRef()
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

		public int? Modulo { get; set; }

		public int? SubAmbito { get; set; }

		public int? Ambito { get; set; }

		public virtual ICollection<TiposActuacionCivilRef> TiposActuacionCivilRef { get; set; }

		[ForeignKey("Modulo")]
		public virtual Modulos Modulos { get; set; }

		[ForeignKey("SubAmbito")]
		public virtual Ambitos SubAmbitos { get; set; }

		[ForeignKey("Ambito")]
		public virtual Ambitos Ambitos { get; set; }
		#endregion

	}
}
