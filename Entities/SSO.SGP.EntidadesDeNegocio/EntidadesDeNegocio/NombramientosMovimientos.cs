
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
	[MetadataTypeAttribute(typeof(NombramientosMovimientosMetaData))]
	[Table("NombramientosMovimientos")]
	public partial class NombramientosMovimientos
	{
		#region Constructor
		public NombramientosMovimientos()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Nombramiento")]
		public int Nombramiento { get; set; }

		[Required(ErrorMessage = "Debe ingresar Desde")]
		public DateTime Desde { get; set; }

		public DateTime? Hasta { get; set; }

		[Required(ErrorMessage = "Debe ingresar Cargo")]
		public int Cargo { get; set; }

		[Required(ErrorMessage = "Debe ingresar SituacionRevista")]
		public string SituacionRevista { get; set; }

		[Required(ErrorMessage = "Debe ingresar Organismo")]
		public int Organismo { get; set; }

		[ForeignKey("Nombramiento")]
		public virtual Nombramientos Nombramientos { get; set; }

		[ForeignKey("Cargo")]
		public virtual CargosRef Cargos { get; set; }

        //[ForeignKey("SituacionRevista")]
        //public virtual SituacionesDeRevista SituacionRevistas { get; set; }

		[ForeignKey("Organismo")]
		public virtual OrganismosRef Organismos { get; set; }
		#endregion

	}
}
