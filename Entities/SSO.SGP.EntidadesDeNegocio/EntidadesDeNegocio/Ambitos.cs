
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
	[MetadataTypeAttribute(typeof(AmbitosMetaData))]
	[Table("Ambitos")]
	public partial class Ambitos
	{
		#region Constructor
		public Ambitos()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripción")]
		[StringLength(50, ErrorMessage ="Descripcion no puede superar los 50 caracteres")]
		public string Descripcion { get; set; }

		public int? AmbitoPrincipal { get; set; }

		[Required(ErrorMessage = "Debe ingresar Edita Detenidos")]
		public bool EditaDetenidos { get; set; }

		[Required(ErrorMessage = "Debe ingresar RecibeCargo")]
		public bool RecibeCargo { get; set; }

		[Required(ErrorMessage = "Debe ingresar CircunscripcionUnica")]
		public bool CircunscripcionUnica { get; set; }

		[Required(ErrorMessage = "Debe ingresar CambioCircunscripcion")]
		public int CambioCircunscripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Protocoliza")]
		public bool Protocoliza { get; set; }

		public bool? CategorizaProtocolo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fuero")]
		public int Fuero { get; set; }

		[ForeignKey("CambioCircunscripcion")]
		public virtual TiposCambiosCircunscripcion CambioCircunscripcions { get; set; }

		[ForeignKey("Fuero")]
		public virtual FuerosRef Fueros { get; set; }
		#endregion

	}
}
