
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
	[MetadataTypeAttribute(typeof(ModalidadesPoliciaRefMetaData))]
	[Table("ModalidadesPoliciaRef")]
	public partial class ModalidadesPoliciaRef
	{
		#region Constructor
		public ModalidadesPoliciaRef()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar IdModalidad")]
		public int IdModalidad { get; set; }

		[Required(ErrorMessage = "Debe ingresar Modalidad")]
		[StringLength(50, ErrorMessage ="Modalidad no puede superar los 50 caracteres")]
		public string Modalidad { get; set; }

		public virtual ICollection<Preventivos> Preventivos { get; set; }
		#endregion

	}
}
