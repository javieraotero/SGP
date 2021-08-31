
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
	[MetadataTypeAttribute(typeof(AcumuladosMetaData))]
	[Table("Acumulados")]
	public partial class Acumulados
	{
		#region Constructor
		public Acumulados()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Juzgado")]
		public int Juzgado { get; set; }

		[Required(ErrorMessage = "Debe ingresar Categoria")]
		public int Categoria { get; set; }

		[Required(ErrorMessage = "Debe ingresar Habilitado")]
		public bool Habilitado { get; set; }

		[Required(ErrorMessage = "Debe ingresar Cantidad")]
		public int Cantidad { get; set; }

		[Required(ErrorMessage = "Debe ingresar Circunscripcion")]
		public int Circunscripcion { get; set; }

		[ForeignKey("Juzgado")]
		public virtual OrganismosRef Juzgados { get; set; }

		[ForeignKey("Categoria")]
		public virtual CategoriasCausas Categorias { get; set; }

		[ForeignKey("Circunscripcion")]
		public virtual CircunscripcionesRef Circunscripcions { get; set; }
		#endregion

	}
}
