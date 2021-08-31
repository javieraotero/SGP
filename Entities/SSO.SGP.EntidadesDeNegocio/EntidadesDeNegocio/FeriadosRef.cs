
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
	[MetadataTypeAttribute(typeof(FeriadosRefMetaData))]
	[Table("FeriadosRef")]
	public partial class FeriadosRef
	{
		#region Constructor
		public FeriadosRef()
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

		[Required(ErrorMessage = "Debe ingresar Dia")]
		public int Dia { get; set; }

		[Required(ErrorMessage = "Debe ingresar Mes")]
		public int Mes { get; set; }

		[Required(ErrorMessage = "Debe ingresar Anio")]
		public int Anio { get; set; }

		[Required(ErrorMessage = "Debe ingresar Movil")]
		public bool Movil { get; set; }

		[Required(ErrorMessage = "Debe ingresar Nacional")]
		public bool Nacional { get; set; }
		#endregion

	}
}
