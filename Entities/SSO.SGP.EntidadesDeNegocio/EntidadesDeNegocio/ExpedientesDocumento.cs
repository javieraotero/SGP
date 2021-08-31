
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
	[MetadataTypeAttribute(typeof(ExpedientesDocumentoMetaData))]
	[Table("ExpedientesDocumento")]
	public partial class ExpedientesDocumento
	{
		#region Constructor
		public ExpedientesDocumento()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		public int? Persona { get; set; }

		public int? DocumentacionPersona { get; set; }

		public int? Delito { get; set; }

		public int? Actuacion { get; set; }

		public int? Elemento { get; set; }

		[Required(ErrorMessage = "Debe ingresar NombreOriginal")]
		[StringLength(255, ErrorMessage ="NombreOriginal no puede superar los 255 caracteres")]
		public string NombreOriginal { get; set; }

		[Required(ErrorMessage = "Debe ingresar Extension")]
		[StringLength(5, ErrorMessage ="Extension no puede superar los 5 caracteres")]
		public string Extension { get; set; }

		[StringLength(255, ErrorMessage ="Descripcion no puede superar los 255 caracteres")]
		public string Descripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Usuario")]
		public int Usuario { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar Confirmado")]
		public bool Confirmado { get; set; }

		public bool? Nosotros { get; set; }

		[ForeignKey("Persona")]
		public virtual ExpedientesPersona Personas { get; set; }

		[ForeignKey("DocumentacionPersona")]
		public virtual Personas DocumentacionPersonas { get; set; }

		[ForeignKey("Delito")]
		public virtual ExpedientesDelito Delitos { get; set; }

		[ForeignKey("Actuacion")]
		public virtual Actuaciones Actuacions { get; set; }

		[ForeignKey("Elemento")]
		public virtual ExpedientesElemento Elementos { get; set; }

		[ForeignKey("Usuario")]
		public virtual Usuarios Usuarios { get; set; }
		#endregion

	}
}
