
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
	[MetadataTypeAttribute(typeof(TurnosMetaData))]
	[Table("Turnos")]
	public partial class Turnos
	{
		#region Constructor
		public Turnos()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Funcionario")]
		public int Funcionario { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaDesde")]
		public DateTime FechaDesde { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaHasta")]
		public DateTime FechaHasta { get; set; }

		[Required(ErrorMessage = "Debe ingresar Cantidad")]
		public int Cantidad { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activa")]
		public bool Activa { get; set; }

		public int? UsuarioAlta { get; set; }

		public DateTime? FechaAlta { get; set; }

		public int? UsuarioModificacion { get; set; }

		public DateTime? FechaModificacion { get; set; }

		public int? UsuarioEliminacion { get; set; }

		public DateTime? FechaEliminacion { get; set; }

		[ForeignKey("Funcionario")]
		public virtual Usuarios Funcionarios { get; set; }
		#endregion

	}
}
