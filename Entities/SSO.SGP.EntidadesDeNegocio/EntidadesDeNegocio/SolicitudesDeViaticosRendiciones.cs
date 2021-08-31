
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
	[MetadataTypeAttribute(typeof(SolicitudesDeViaticosRendicionesMetaData))]
	[Table("SolicitudesDeViaticosRendiciones")]
	public partial class SolicitudesDeViaticosRendiciones
	{
		#region Constructor
		public SolicitudesDeViaticosRendiciones()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar SolicitudDeViatico")]
		public int SolicitudDeViatico { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaDeInicio")]
		public DateTime FechaDeInicio { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaDeFin")]
		public DateTime FechaDeFin { get; set; }

		[Required(ErrorMessage = "Debe ingresar TotalBienesDeConsumo")]
		public decimal TotalBienesDeConsumo { get; set; }

		[Required(ErrorMessage = "Debe ingresar TotalServiciosNoPersonales")]
		public decimal TotalServiciosNoPersonales { get; set; }

		[Required(ErrorMessage = "Debe ingresar TotalOtros")]
		public decimal TotalOtros { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaDeAlta")]
		public DateTime FechaDeAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioAlta")]
		public int UsuarioAlta { get; set; }

		public virtual ICollection<SolicitudesDeViaticosRendicionesAgentes> SolicitudesDeViaticosRendicionesAgentes { get; set; }

		[ForeignKey("SolicitudDeViatico")]
		public virtual SolicitudesDeViaticos SolicitudDeViaticos { get; set; }
		#endregion

	}
}
