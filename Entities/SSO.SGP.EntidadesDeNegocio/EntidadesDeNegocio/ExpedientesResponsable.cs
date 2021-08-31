
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
	[MetadataTypeAttribute(typeof(ExpedientesResponsableMetaData))]
	[Table("ExpedientesResponsable")]
	public partial class ExpedientesResponsable
	{
		#region Constructor
		public ExpedientesResponsable()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Expediente")]
		public int Expediente { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fecha")]
		public DateTime Fecha { get; set; }

		[Required(ErrorMessage = "Debe ingresar Responsable")]
		public int Responsable { get; set; }

		[Required(ErrorMessage = "Debe ingresar Cargo")]
		public int Cargo { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioAsignacion")]
		public int UsuarioAsignacion { get; set; }

		[StringLength(255, ErrorMessage ="Observaciones no puede superar los 255 caracteres")]
		public string Observaciones { get; set; }

		[Required(ErrorMessage = "Debe ingresar PorSorteo")]
		public bool PorSorteo { get; set; }

		[ForeignKey("Expediente")]
		public virtual Expedientes Expedientes { get; set; }

		[ForeignKey("Responsable")]
		public virtual Usuarios Responsables { get; set; }

		[ForeignKey("Cargo")]
		public virtual CargosFuncionalesRef Cargos { get; set; }

		[ForeignKey("UsuarioAsignacion")]
		public virtual Usuarios UsuarioAsignacions { get; set; }
		#endregion

	}
}
