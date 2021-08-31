
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
	[MetadataTypeAttribute(typeof(PersonasCaracteristicasRefMetaData))]
	[Table("PersonasCaracteristicasRef")]
	public partial class PersonasCaracteristicasRef
	{
		#region Constructor
		public PersonasCaracteristicasRef()
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

		[Required(ErrorMessage = "Debe ingresar Tipo")]
		public int Tipo { get; set; }

        //public virtual ICollection<Personas> Personas { get; set; }

        //public virtual ICollection<Personas> Personas1 { get; set; }

        //public virtual ICollection<Personas> Personas10 { get; set; }

        //public virtual ICollection<Personas> Personas11 { get; set; }

        //public virtual ICollection<Personas> Personas2 { get; set; }

        //public virtual ICollection<Personas> Personas3 { get; set; }

        //public virtual ICollection<Personas> Personas4 { get; set; }

        //public virtual ICollection<Personas> Personas5 { get; set; }

        //public virtual ICollection<Personas> Personas6 { get; set; }

        //public virtual ICollection<Personas> Personas7 { get; set; }

        //public virtual ICollection<Personas> Personas8 { get; set; }

        //public virtual ICollection<Personas> Personas9 { get; set; }

		[ForeignKey("Tipo")]
		public virtual TiposPersonaCaracteristicaRef Tipos { get; set; }
		#endregion

	}
}
