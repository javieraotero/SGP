
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
	[MetadataTypeAttribute(typeof(ConcursosMetaData))]
	[Table("Concursos")]
	public partial class Concursos
	{
		#region Constructor
		public Concursos()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[StringLength(15, ErrorMessage ="Actividad no puede superar los 15 caracteres")]
		public string Actividad { get; set; }

		[StringLength(50, ErrorMessage ="RazonSocial no puede superar los 50 caracteres")]
		public string RazonSocial { get; set; }

		[StringLength(50, ErrorMessage ="DomicilioComercial no puede superar los 50 caracteres")]
		public string DomicilioComercial { get; set; }

		public int? MatriculaRazonSocial { get; set; }

		public int? FolioRazonSocial { get; set; }

		public int? TomoRazonSocial { get; set; }

		public int? AnioRazonSocial { get; set; }

		public int? MatriculaComerciante { get; set; }

		public int? FolioComerciante { get; set; }

		public int? TomoComerciante { get; set; }

		public int? AnioComerciante { get; set; }

        //public virtual ICollection<Personas> Personas { get; set; }
		#endregion

	}
}
