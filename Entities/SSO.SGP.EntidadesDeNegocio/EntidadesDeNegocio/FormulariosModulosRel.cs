
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
	[MetadataTypeAttribute(typeof(FormulariosModulosRelMetaData))]
	[Table("FormulariosModulosRel")]
	public partial class FormulariosModulosRel
	{
		#region Constructor
		public FormulariosModulosRel()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Formulario { get; set; }

		[Key]
		public int Modulo { get; set; }

		[ForeignKey("Formulario")]
		public virtual Formularios Formularios { get; set; }

		[ForeignKey("Modulo")]
		public virtual Modulos Modulos { get; set; }
		#endregion

	}
}
