
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
	[MetadataTypeAttribute(typeof(ExpedientesDocumentoadmMetaData))]
	[Table("ExpedientesDocumentoadm")]
	public partial class ExpedientesDocumentoadm
	{
		#region Constructor
		public ExpedientesDocumentoadm()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		public int? Persona { get; set; }

		public int? Actuacion { get; set; }

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

        public int? Expediente { get; set; }

        //[ForeignKey("Persona")]
        //public virtual Personas Personas { get; set; }

        [ForeignKey("Actuacion")]
		public virtual Actuacionesadm Actuacions { get; set; }

		//[ForeignKey("Usuario")]
		//public virtual Usuarios Usuarios { get; set; }
		#endregion

	}
}
