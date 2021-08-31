
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
	[MetadataTypeAttribute(typeof(MovimientosDeAgentesMetaData))]
	[Table("MovimientosDeAgentes")]
	public partial class MovimientosDeAgentes
	{
		#region Constructor
		public MovimientosDeAgentes()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Nombramiento")]
		public int Nombramiento { get; set; }

		public int? NuevoCargo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fecha")]
		public DateTime Fecha { get; set; }

		public int? NuevoOrganismo { get; set; }

		[ForeignKey("NuevoCargo")]
		public virtual CargosRef NuevoCargos { get; set; }

		[ForeignKey("NuevoOrganismo")]
		public virtual OrganismosRef NuevoOrganismos { get; set; }
		#endregion

	}
}
