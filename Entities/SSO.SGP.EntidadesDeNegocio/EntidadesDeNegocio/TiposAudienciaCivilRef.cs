
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
	[MetadataTypeAttribute(typeof(TiposAudienciaCivilRefMetaData))]
	[Table("TiposAudienciaCivilRef")]
	public partial class TiposAudienciaCivilRef
	{
		#region Constructor
		public TiposAudienciaCivilRef()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		[StringLength(100, ErrorMessage ="Descripcion no puede superar los 100 caracteres")]
		public string Descripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar EnUso")]
		public bool EnUso { get; set; }

		[Required(ErrorMessage = "Debe ingresar Ambito")]
		public int Ambito { get; set; }

		public virtual ICollection<AudienciasCivil> AudienciasCivil { get; set; }

		[ForeignKey("Ambito")]
		public virtual Ambitos Ambitos { get; set; }
		#endregion

	}
}
