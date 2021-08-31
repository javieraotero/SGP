
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
	[MetadataTypeAttribute(typeof(FeriasRefMetaData))]
	[Table("FeriasRef")]
	public partial class FeriasRef
	{
		#region Constructor
		public FeriasRef()
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

		[Required(ErrorMessage = "Debe ingresar FechaDesde")]
		public DateTime FechaDesde { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaHasta")]
		public DateTime FechaHasta { get; set; }

		[Required(ErrorMessage = "Debe ingresar Anio")]
		public int Anio { get; set; }

		[Required(ErrorMessage = "Debe ingresar DiaDesde")]
		public int DiaDesde { get; set; }

		[Required(ErrorMessage = "Debe ingresar MesDesde")]
		public int MesDesde { get; set; }

		[Required(ErrorMessage = "Debe ingresar DiaHasta")]
		public int DiaHasta { get; set; }

		[Required(ErrorMessage = "Debe ingresar MesHasta")]
		public int MesHasta { get; set; }

		[Required(ErrorMessage = "Debe ingresar Paso1")]
		public bool Paso1 { get; set; }

		[Required(ErrorMessage = "Debe ingresar Paso2")]
		public bool Paso2 { get; set; }

		public virtual ICollection<FeriasAgentes> FeriasAgentes { get; set; }
		#endregion

	}
}
