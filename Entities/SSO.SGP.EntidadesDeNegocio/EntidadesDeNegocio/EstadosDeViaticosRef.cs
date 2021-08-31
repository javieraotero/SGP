
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
	[MetadataTypeAttribute(typeof(EstadosDeViaticosRefMetaData))]
	[Table("EstadosDeViaticosRef")]
	public partial class EstadosDeViaticosRef
	{
		#region Constructor
		public EstadosDeViaticosRef()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		public string  Descripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar EditaOrganismo")]
		public bool EditaOrganismo { get; set; }

		[Required(ErrorMessage = "Debe ingresar EditaEconomia")]
		public bool EditaEconomia { get; set; }
		#endregion

	}
}
