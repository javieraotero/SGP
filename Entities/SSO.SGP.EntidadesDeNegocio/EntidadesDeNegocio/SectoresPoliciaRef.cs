
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
	[MetadataTypeAttribute(typeof(SectoresPoliciaRefMetaData))]
	[Table("SectoresPoliciaRef")]
	public partial class SectoresPoliciaRef
	{
		#region Constructor
		public SectoresPoliciaRef()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		public int? IdSector { get; set; }

		[Required(ErrorMessage = "Debe ingresar Sector")]
		[StringLength(5, ErrorMessage ="Sector no puede superar los 5 caracteres")]
		public string Sector { get; set; }

		[StringLength(50, ErrorMessage ="Barrio no puede superar los 50 caracteres")]
		public string Barrio { get; set; }

		[Required(ErrorMessage = "Debe ingresar Unidad")]
		public int Unidad { get; set; }

		public int? Comisaria { get; set; }

		public virtual ICollection<Preventivos> Preventivos { get; set; }

		[ForeignKey("Comisaria")]
		public virtual OrganismosRef Comisarias { get; set; }
		#endregion

	}
}
