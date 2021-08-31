
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
	[MetadataTypeAttribute(typeof(EstadosCausaRefMetaData))]
	[Table("EstadosCausaRef")]
	public partial class EstadosCausaRef
	{
		#region Constructor
		public EstadosCausaRef()
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

		[Required(ErrorMessage = "Debe ingresar GrupoEstado")]
		public int GrupoEstado { get; set; }

		public virtual ICollection<Causas> Causas { get; set; }

		public virtual ICollection<CausasEstado> CausasEstado { get; set; }

		[ForeignKey("GrupoEstado")]
		public virtual GruposEstadoCausaRef GrupoEstados { get; set; }
		#endregion

	}
}
