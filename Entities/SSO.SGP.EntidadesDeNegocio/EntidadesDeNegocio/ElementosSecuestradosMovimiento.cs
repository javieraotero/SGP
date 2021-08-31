
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
	[MetadataTypeAttribute(typeof(ElementosSecuestradosMovimientoMetaData))]
	[Table("ElementosSecuestradosMovimiento")]
	public partial class ElementosSecuestradosMovimiento
	{
		#region Constructor
		public ElementosSecuestradosMovimiento()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Elemento")]
		public int Elemento { get; set; }

		[Required(ErrorMessage = "Debe ingresar Persona")]
		public int Persona { get; set; }

		[Required(ErrorMessage = "Debe ingresar Motivo")]
		public int Motivo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fecha")]
		public DateTime Fecha { get; set; }

		[StringLength(2147483647, ErrorMessage ="Estado no puede superar los 2147483647 caracteres")]
		public string Estado { get; set; }

		[StringLength(255, ErrorMessage ="Observaciones no puede superar los 255 caracteres")]
		public string Observaciones { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar Usuario")]
		public int Usuario { get; set; }

		[ForeignKey("Elemento")]
		public virtual ElementosSecuestrados Elementos { get; set; }

		[ForeignKey("Persona")]
		public virtual Personas Personas { get; set; }

		[ForeignKey("Motivo")]
		public virtual MotivosElementosSecuentradosMovimientoRef Motivos { get; set; }

		[ForeignKey("Usuario")]
		public virtual Usuarios Usuarios { get; set; }
		#endregion

	}
}
