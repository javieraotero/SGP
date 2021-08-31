
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
	[MetadataTypeAttribute(typeof(ImagenesrrhhMetaData))]
	[Table("Imagenesrrhh")]
	public partial class Imagenesrrhh
	{
		#region Constructor
		public Imagenesrrhh()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Nombre")]
		[StringLength(255, ErrorMessage ="Nombre no puede superar los 255 caracteres")]
		public string Nombre { get; set; }

		[Required(ErrorMessage = "Debe ingresar Categoria")]
		public int Categoria { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaDeCarga")]
		public DateTime FechaDeCarga { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaUltimaActualizacion")]
		public DateTime FechaUltimaActualizacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Usuario")]
		public int Usuario { get; set; }

		[Required(ErrorMessage = "Debe ingresar Agente")]
		public int Agente { get; set; }

		[Required(ErrorMessage = "Debe ingresar Imagen")]
		[StringLength(100, ErrorMessage ="Imagen no puede superar los 100 caracteres")]
		public string Imagen { get; set; }

		[StringLength(100, ErrorMessage ="Firma no puede superar los 100 caracteres")]
		public string Firma { get; set; }

		[ForeignKey("Categoria")]
		public virtual CategoriasDeImagenesRef Categorias { get; set; }

		[ForeignKey("Usuario")]
		public virtual Usuarios Usuarios { get; set; }

		[ForeignKey("Agente")]
		public virtual Agentes Agentes { get; set; }

        public string Descripcion { get; set; }

		#endregion

	}
}
