
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
	[MetadataTypeAttribute(typeof(MateriasMetaData))]
	[Table("Materias")]
	public partial class Materias
	{
		#region Constructor
		public Materias()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		[StringLength(255, ErrorMessage ="Descripcion no puede superar los 255 caracteres")]
		public string Descripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Mnemo")]
		[StringLength(5, ErrorMessage ="Mnemo no puede superar los 5 caracteres")]
		public string Mnemo { get; set; }

		public int? Tipo { get; set; }

		[Required(ErrorMessage = "Debe ingresar EjerceAtraccion")]
		public bool EjerceAtraccion { get; set; }

		public int? Civil { get; set; }

		public int? Laboral { get; set; }

		[Required(ErrorMessage = "Debe ingresar Publica")]
		public bool Publica { get; set; }

		public int? Familia { get; set; }

		[Required(ErrorMessage = "Debe ingresar Exorto")]
		public bool Exorto { get; set; }

		[Required(ErrorMessage = "Debe ingresar Vigente")]
		public bool Vigente { get; set; }

		[Required(ErrorMessage = "Debe ingresar Mediacion")]
		public int Mediacion { get; set; }

		public int? Concursos_Quiebras { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activo")]
		public bool Activo { get; set; }

		public int? CategoriaUnica { get; set; }

		public virtual ICollection<Causas> Causas { get; set; }

		[ForeignKey("Tipo")]
		public virtual TiposMateriasRef Tipos { get; set; }

		[ForeignKey("Civil")]
		public virtual CategoriasCausas Civils { get; set; }

		[ForeignKey("Laboral")]
		public virtual CategoriasCausas Laborals { get; set; }

		[ForeignKey("Familia")]
		public virtual CategoriasCausas Familias { get; set; }

		[ForeignKey("Concursos_Quiebras")]
		public virtual CategoriasCausas Concursos_Quiebrass { get; set; }

		[ForeignKey("CategoriaUnica")]
		public virtual CategoriasCausas CategoriaUnicas { get; set; }
		#endregion

	}
}
