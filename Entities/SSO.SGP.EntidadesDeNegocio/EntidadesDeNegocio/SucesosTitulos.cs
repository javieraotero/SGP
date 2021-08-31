
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
	[MetadataTypeAttribute(typeof(SucesosTitulosMetaData))]
	[Table("SucesosTitulos")]
	public partial class SucesosTitulos
	{
		#region Constructor
		public SucesosTitulos()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		[StringLength(100, ErrorMessage ="Descripcion no puede superar los 100 caracteres")]
		public string Descripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Ambito")]
		public int Ambito { get; set; }

		[Required(ErrorMessage = "Debe ingresar TipoSuceso")]
		public int TipoSuceso { get; set; }

		[Required(ErrorMessage = "Debe ingresar MostrarEnEdicion")]
		public bool MostrarEnEdicion { get; set; }

		[Required(ErrorMessage = "Debe ingresar AplicaSuspencionPlazo")]
		public bool AplicaSuspencionPlazo { get; set; }

		public int? Circunscripcion { get; set; }

		public int? UsuarioAlta { get; set; }

		public DateTime? FechaAlta { get; set; }

		public int? UsuarioModifica { get; set; }

		public DateTime? FechaModifica { get; set; }

		public int? UsuarioElimina { get; set; }

		public DateTime? FechaElimina { get; set; }

		public virtual ICollection<Sucesos> Sucesos { get; set; }

		public virtual ICollection<SucesosCausas> SucesosCausas { get; set; }

		[ForeignKey("Ambito")]
		public virtual Ambitos Ambitos { get; set; }

		[ForeignKey("TipoSuceso")]
		public virtual TiposSucesos TipoSucesos { get; set; }

		[ForeignKey("Circunscripcion")]
		public virtual CircunscripcionesRef Circunscripcions { get; set; }
		#endregion

	}
}
