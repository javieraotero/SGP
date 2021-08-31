
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
	[MetadataTypeAttribute(typeof(CompraDeSuministrosMetaData))]
	[Table("CompraDeSuministros")]
	public partial class CompraDeSuministros
	{
		#region Constructor
		public CompraDeSuministros()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fecha")]
		public DateTime Fecha { get; set; }

		[StringLength(20, ErrorMessage ="Comprobante no puede superar los 20 caracteres")]
		public string Comprobante { get; set; }

		[Required(ErrorMessage = "Debe ingresar Usuario")]
		public int Usuario { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaDeCarga")]
		public DateTime FechaDeCarga { get; set; }

		public virtual ICollection<ArticulosDeComprasDeSuministros> ArticulosDeComprasDeSuministros { get; set; }

        public DateTime? FechaDeBaja { get; set; }

        public int? UsuarioBaja { get; set; }

		[ForeignKey("Usuario")]
		public virtual Usuarios Usuarios { get; set; }
		#endregion

	}
}
