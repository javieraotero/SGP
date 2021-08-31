
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
	[MetadataTypeAttribute(typeof(ElementosSecuestradosMetaData))]
	[Table("ElementosSecuestrados")]
	public partial class ElementosSecuestrados
	{
		#region Constructor
		public ElementosSecuestrados()
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

		[Required(ErrorMessage = "Debe ingresar Deposito")]
		public int Deposito { get; set; }

		[Required(ErrorMessage = "Debe ingresar NroEstanteria")]
		[StringLength(50, ErrorMessage ="NroEstanteria no puede superar los 50 caracteres")]
		public string NroEstanteria { get; set; }

		[Required(ErrorMessage = "Debe ingresar NroEstante")]
		[StringLength(50, ErrorMessage ="NroEstante no puede superar los 50 caracteres")]
		public string NroEstante { get; set; }

		[Required(ErrorMessage = "Debe ingresar DescirpcionDetallada")]
		[StringLength(2147483647, ErrorMessage ="DescirpcionDetallada no puede superar los 2147483647 caracteres")]
		public string DescirpcionDetallada { get; set; }

		[Required(ErrorMessage = "Debe ingresar Estado")]
		public int Estado { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar Usuario")]
		public int Usuario { get; set; }

		[StringLength(255, ErrorMessage ="Observaciones no puede superar los 255 caracteres")]
		public string Observaciones { get; set; }

		[StringLength(50, ErrorMessage ="Caja no puede superar los 50 caracteres")]
		public string Caja { get; set; }

		public virtual ICollection<ElementosSecuestradosDocumento> ElementosSecuestradosDocumento { get; set; }

		public virtual ICollection<ElementosSecuestradosMovimiento> ElementosSecuestradosMovimiento { get; set; }

		[ForeignKey("Expediente")]
		public virtual Expedientes Expedientes { get; set; }

		[ForeignKey("Deposito")]
		public virtual OrganismosRef Depositos { get; set; }

		[ForeignKey("Estado")]
		public virtual EstadosElementosSecuestradosRef Estados { get; set; }

		[ForeignKey("Usuario")]
		public virtual Usuarios Usuarios { get; set; }
		#endregion

	}
}
