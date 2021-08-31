
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
	[MetadataTypeAttribute(typeof(BarriosRefMetaData))]
	[Table("BarriosRef")]
	public partial class BarriosRef
	{
		#region Constructor
		public BarriosRef()
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

		[Required(ErrorMessage = "Debe ingresar Localidad")]
		public int Localidad { get; set; }

        //public virtual ICollection<ExpedientesDelito> ExpedientesDelito { get; set; }

        //public virtual ICollection<ExpedientesPersona> ExpedientesPersona { get; set; }

        //public virtual ICollection<ExpedientesPersona> ExpedientesPersona1 { get; set; }

        //public virtual ICollection<ExpedientesPersona> ExpedientesPersona2 { get; set; }

        //public virtual ICollection<Personas> Personas { get; set; }

		[ForeignKey("Localidad")]
		public virtual LocalidadesRef Localidads { get; set; }
		#endregion

	}
}
