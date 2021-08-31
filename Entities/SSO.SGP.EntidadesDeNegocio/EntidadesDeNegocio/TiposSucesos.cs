
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
	[MetadataTypeAttribute(typeof(TiposSucesosMetaData))]
	[Table("TiposSucesos")]
	public partial class TiposSucesos
	{
		#region Constructor
		public TiposSucesos()
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

		[Required(ErrorMessage = "Debe ingresar TareaManual")]
		public bool TareaManual { get; set; }

		public virtual ICollection<Sucesos> Sucesos { get; set; }

		public virtual ICollection<SucesosCausas> SucesosCausas { get; set; }

		public virtual ICollection<SucesosTitulos> SucesosTitulos { get; set; }
		#endregion

	}
}
