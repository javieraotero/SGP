
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
	[MetadataTypeAttribute(typeof(GrupoElementosPoliciaRefMetaData))]
	[Table("GrupoElementosPoliciaRef")]
	public partial class GrupoElementosPoliciaRef
	{
		#region Constructor
		public GrupoElementosPoliciaRef()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar IdSigla")]
		public int IdSigla { get; set; }

		[Required(ErrorMessage = "Debe ingresar Sigla")]
		[StringLength(5, ErrorMessage ="Sigla no puede superar los 5 caracteres")]
		public string Sigla { get; set; }

		[Required(ErrorMessage = "Debe ingresar ElementosSigla")]
		[StringLength(250, ErrorMessage ="ElementosSigla no puede superar los 250 caracteres")]
		public string ElementosSigla { get; set; }

		public virtual ICollection<PreventivosElementos> PreventivosElementos { get; set; }
		#endregion

	}
}
