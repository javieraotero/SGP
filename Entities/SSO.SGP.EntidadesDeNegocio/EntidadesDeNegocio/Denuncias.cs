
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
	[MetadataTypeAttribute(typeof(DenunciasMetaData))]
	[Table("Denuncias")]
	public partial class Denuncias
	{
		#region Constructor
		public Denuncias()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Titulo")]
		[StringLength(100, ErrorMessage ="Titulo no puede superar los 100 caracteres")]
		public string Titulo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		[StringLength(1073741823, ErrorMessage ="Descripcion no puede superar los 1073741823 caracteres")]
		public string Descripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Tipo")]
		public int Tipo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Comisaria")]
		public int Comisaria { get; set; }

		[Required(ErrorMessage = "Debe ingresar GeneradaEnPreventivo")]
		public bool GeneradaEnPreventivo { get; set; }

		public int? Preventivo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activo")]
		public bool Activo { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioAlta")]
		public int UsuarioAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaModifica")]
		public DateTime FechaModifica { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioModifica")]
		public int UsuarioModifica { get; set; }

		public DateTime? FechaElimina { get; set; }

		public int? UsuarioElimina { get; set; }

		[ForeignKey("Tipo")]
		public virtual TiposDenunciasRef Tipos { get; set; }

		[ForeignKey("Comisaria")]
		public virtual OrganismosRef Comisarias { get; set; }

		[ForeignKey("Preventivo")]
		public virtual Preventivos Preventivos { get; set; }

		[ForeignKey("UsuarioAlta")]
		public virtual Usuarios UsuarioAltas { get; set; }
		#endregion

	}
}
