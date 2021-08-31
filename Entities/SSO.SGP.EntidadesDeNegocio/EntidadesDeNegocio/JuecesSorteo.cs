
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
	[MetadataTypeAttribute(typeof(JuecesSorteoMetaData))]
	[Table("JuecesSorteo")]
	public partial class JuecesSorteo
	{
		#region Constructor
		public JuecesSorteo()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar JuezSorteado")]
		public int JuezSorteado { get; set; }

		[Required(ErrorMessage = "Debe ingresar Delito")]
		public int Delito { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioSorteo")]
		public int UsuarioSorteo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fecha")]
		public DateTime Fecha { get; set; }

		[Required(ErrorMessage = "Debe ingresar Expediente")]
		public int Expediente { get; set; }

		[StringLength(500, ErrorMessage ="Observaciones no puede superar los 500 caracteres")]
		public string Observaciones { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activo")]
		public bool Activo { get; set; }

		[ForeignKey("JuezSorteado")]
		public virtual Usuarios JuezSorteados { get; set; }

		[ForeignKey("Delito")]
		public virtual DelitosRef Delitos { get; set; }

		[ForeignKey("UsuarioSorteo")]
		public virtual Usuarios UsuarioSorteos { get; set; }

		[ForeignKey("Expediente")]
		public virtual Expedientes Expedientes { get; set; }
		#endregion

	}
}
