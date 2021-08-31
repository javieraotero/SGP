
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
	//[MetadataTypeAttribute(typeof(TurnosWebParametrosMetaData))]
	[Table("ECO_ProveedoresSocios")]
	public partial class ECO_ProveedoresSocios
	{
		#region Constructor
		public ECO_ProveedoresSocios()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }
		public int Proveedor { get; set; }
		[MaxLength(200)]
		public string Socio { get; set; }

		public int? Persona { get; set; }

		public eTipoSocioProveedores Tipo { get; set; }

		public DateTime FechaAlta { get; set; }

		[ForeignKey("Proveedor")]
		public virtual ECO_Proveedores Proveedor_{ get; set; }
		[ForeignKey("Persona")]
		public virtual Personas Persona_ { get; set; }

		public string DniSocio { get; set; }
		#endregion

	}
}
