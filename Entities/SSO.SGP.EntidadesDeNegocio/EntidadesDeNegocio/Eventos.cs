
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
	[MetadataTypeAttribute(typeof(EventosMetaData))]
	[Table("Eventos")]
	public partial class Eventos
	{
		#region Constructor
		public Eventos()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fecha")]
		public DateTime Fecha { get; set; }

		[Required(ErrorMessage = "Debe ingresar Oficina")]
		public int Oficina { get; set; }

		[Required(ErrorMessage = "Debe ingresar Usuario")]
		public int Usuario { get; set; }

		[Required(ErrorMessage = "Debe ingresar Titulo")]
		[StringLength(50, ErrorMessage ="Titulo no puede superar los 50 caracteres")]
		public string Titulo { get; set; }

		[StringLength(255, ErrorMessage ="Descripcion no puede superar los 255 caracteres")]
		public string Descripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar AlcanceEvento")]
		public int AlcanceEvento { get; set; }

		public int? Expediente { get; set; }

		public int? Audiencia { get; set; }

		public DateTime? FechaAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activo")]
		public bool Activo { get; set; }

		[ForeignKey("Oficina")]
		public virtual OrganismosRef Oficinas { get; set; }

		[ForeignKey("Usuario")]
		public virtual Usuarios Usuarios { get; set; }

		[ForeignKey("Expediente")]
		public virtual Expedientes Expedientes { get; set; }

		[ForeignKey("Audiencia")]
		public virtual Audiencias Audiencias { get; set; }
		#endregion

	}
}
