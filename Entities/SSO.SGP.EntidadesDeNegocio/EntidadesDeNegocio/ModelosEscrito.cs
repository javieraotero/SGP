
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
	[MetadataTypeAttribute(typeof(ModelosEscritoMetaData))]
	[Table("ModelosEscrito")]
	public partial class ModelosEscrito
	{
		#region Constructor
		public ModelosEscrito()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		public int? Oficina { get; set; }

		[Required(ErrorMessage = "Debe ingresar Titulo")]
		[StringLength(255, ErrorMessage ="Titulo no puede superar los 255 caracteres")]
		public string Titulo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Contenido")]
		[StringLength(2147483647, ErrorMessage ="Contenido no puede superar los 2147483647 caracteres")]
		public string Contenido { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar Usuario")]
		public int Usuario { get; set; }

		[Required(ErrorMessage = "Debe ingresar Tipo")]
		public int Tipo { get; set; }

		public int? TipoActuacion { get; set; }

		public int? UsuarioModifica { get; set; }

		public DateTime? FechaModifica { get; set; }

		//public virtual ICollection<Actuacionesadm> Actuacionesadm { get; set; }

		[ForeignKey("Oficina")]
		public virtual OrganismosRef Oficinas { get; set; }

		//[ForeignKey("Usuario")]
		//public virtual Usuarios Usuarios { get; set; }

		[ForeignKey("Tipo")]
		public virtual TiposModeloEscritoRef Tipos { get; set; }

		[ForeignKey("TipoActuacion")]
		public virtual TiposActuacionRef TipoActuacions { get; set; }
		#endregion

	}
}
