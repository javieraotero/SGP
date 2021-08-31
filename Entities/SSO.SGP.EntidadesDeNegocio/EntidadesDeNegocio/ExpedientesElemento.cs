
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
	[MetadataTypeAttribute(typeof(ExpedientesElementoMetaData))]
	[Table("ExpedientesElemento")]
	public partial class ExpedientesElemento
	{
		#region Constructor
		public ExpedientesElemento()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Expediente")]
		public int Expediente { get; set; }

		[Required(ErrorMessage = "Debe ingresar Codigo")]
		[StringLength(20, ErrorMessage ="Codigo no puede superar los 20 caracteres")]
		public string Codigo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Numerador")]
		public int Numerador { get; set; }

		[Required(ErrorMessage = "Debe ingresar Rol")]
		public int Rol { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		[StringLength(2147483647, ErrorMessage ="Descripcion no puede superar los 2147483647 caracteres")]
		public string Descripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Confirmado")]
		public bool Confirmado { get; set; }

		public bool? Activo { get; set; }

		public DateTime? FechaAlta { get; set; }

		public int? UsuarioAlta { get; set; }

		public DateTime? FechaModificacion { get; set; }

		public int? UsuarioModificacion { get; set; }

		public DateTime? FechaBaja { get; set; }

		public int? UsuarioBaja { get; set; }

		public int? NumeroPaquete { get; set; }

		public virtual ICollection<ExpedientesDocumento> ExpedientesDocumento { get; set; }

		[ForeignKey("Expediente")]
		public virtual Expedientes Expedientes { get; set; }

		[ForeignKey("Rol")]
		public virtual RolesElementoRef Rols { get; set; }

		[ForeignKey("UsuarioAlta")]
		public virtual Usuarios UsuarioAltas { get; set; }

		[ForeignKey("UsuarioModificacion")]
		public virtual Usuarios UsuarioModificacions { get; set; }

		[ForeignKey("UsuarioBaja")]
		public virtual Usuarios UsuarioBajas { get; set; }
		#endregion

	}
}
