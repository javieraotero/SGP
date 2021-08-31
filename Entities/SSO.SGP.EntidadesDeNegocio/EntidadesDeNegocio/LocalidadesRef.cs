
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
	[MetadataTypeAttribute(typeof(LocalidadesRefMetaData))]
	[Table("LocalidadesRef")]
	public partial class LocalidadesRef
	{
		#region Constructor
		public LocalidadesRef()
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

		[StringLength(15, ErrorMessage ="CodigoPostal no puede superar los 15 caracteres")]
		public string CodigoPostal { get; set; }

		[Required(ErrorMessage = "Debe ingresar Provincia")]
		public int Provincia { get; set; }

		[Required(ErrorMessage = "Debe ingresar Abreviatura")]
		[StringLength(5, ErrorMessage ="Abreviatura no puede superar los 5 caracteres")]
		public string Abreviatura { get; set; }

		[Required(ErrorMessage = "Debe ingresar TieneCallesCargadas")]
		public bool TieneCallesCargadas { get; set; }

        //public virtual ICollection<BarriosRef> BarriosRef { get; set; }

        //public virtual ICollection<Conexiones> Conexiones { get; set; }

		[ForeignKey("Provincia")]
		public virtual ProvinciasRef Provincias { get; set; }
		#endregion

	}
}
