
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
	[MetadataTypeAttribute(typeof(TablasMetaData))]
	[Table("Tablas")]
	public partial class Tablas
	{
		#region Constructor
		public Tablas()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Nombre")]
		[StringLength(50, ErrorMessage ="Nombre no puede superar los 50 caracteres")]
		public string Nombre { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		[StringLength(255, ErrorMessage ="Descripcion no puede superar los 255 caracteres")]
		public string Descripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar DelSistema")]
		public bool DelSistema { get; set; }

		[Required(ErrorMessage = "Debe ingresar SoloLectura")]
		public bool SoloLectura { get; set; }

		[Required(ErrorMessage = "Debe ingresar Clase")]
		[StringLength(50, ErrorMessage ="Clase no puede superar los 50 caracteres")]
		public string Clase { get; set; }

		[Required(ErrorMessage = "Debe ingresar HabilitarEliminacion")]
		public bool HabilitarEliminacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Orden")]
		[StringLength(50, ErrorMessage ="Orden no puede superar los 50 caracteres")]
		public string Orden { get; set; }

		[Required(ErrorMessage = "Debe ingresar AdministrarPorGenerico")]
		public bool AdministrarPorGenerico { get; set; }

		public virtual ICollection<Columnas> Columnas { get; set; }
		#endregion

	}
}
