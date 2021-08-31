
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
	[MetadataTypeAttribute(typeof(PasosMetaData))]
	[Table("Pasos")]
	public partial class Pasos
	{
		#region Constructor
		public Pasos()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Causa")]
		public int Causa { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fecha")]
		public DateTime Fecha { get; set; }

		[Required(ErrorMessage = "Debe ingresar Motivo")]
		[StringLength(255, ErrorMessage ="Motivo no puede superar los 255 caracteres")]
		public string Motivo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Usuario")]
		public int Usuario { get; set; }

		[ForeignKey("Causa")]
		public virtual Causas Causas { get; set; }

		[ForeignKey("Usuario")]
		public virtual Usuarios Usuarios { get; set; }
		#endregion

	}
}
