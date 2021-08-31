
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
	[MetadataTypeAttribute(typeof(CargosRefMetaData))]
	[Table("CargosRef")]
	public partial class CargosRef
	{
		#region Constructor
		public CargosRef()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		[StringLength(100, ErrorMessage ="Descripcion no puede superar los 100 caracteres")]
		public string Descripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Orden")]
		public int Orden { get; set; }

		[Required(ErrorMessage = "Debe ingresar Grupo")]
		public int Grupo { get; set; }

		public int? CodigoRRHH { get; set; }

		public int? Presupuesto { get; set; }

        //public virtual ICollection<Agentes> Agentes { get; set; }
		#endregion

	}
}
