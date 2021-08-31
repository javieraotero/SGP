
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
	[MetadataTypeAttribute(typeof(DelitosRefMetaData))]
	[Table("DelitosRef")]
	public partial class DelitosRef
	{
		#region Constructor
		public DelitosRef()
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

		[Required(ErrorMessage = "Debe ingresar Articulos")]
		[StringLength(100, ErrorMessage ="Articulos no puede superar los 100 caracteres")]
		public string Articulos { get; set; }

		[Required(ErrorMessage = "Debe ingresar MesesPrescribe")]
		public int MesesPrescribe { get; set; }

		[Required(ErrorMessage = "Debe ingresar MapaDelito")]
		public bool MapaDelito { get; set; }

		[Required(ErrorMessage = "Debe ingresar Capitulo")]
		public int Capitulo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activo")]
		public bool Activo { get; set; }

		[Required(ErrorMessage = "Debe ingresar NivelPonderacion_CircI")]
		public int NivelPonderacion_CircI { get; set; }

		[Required(ErrorMessage = "Debe ingresar NivelPonderacion_CircII")]
		public int NivelPonderacion_CircII { get; set; }

		[Required(ErrorMessage = "Debe ingresar NivelPonderacion_CircIII")]
		public int NivelPonderacion_CircIII { get; set; }

		[Required(ErrorMessage = "Debe ingresar NivelPonderacion_CircIV")]
		public int NivelPonderacion_CircIV { get; set; }

		public int? CondenaMinima { get; set; }

		public int? TipoCondenaMinima { get; set; }

		public int? CondenaMaxima { get; set; }

		public int? TipoCondenaMaxima { get; set; }

		public double? Ponderacion { get; set; }

		public int? Prescripcion { get; set; }

		public virtual ICollection<DelitosRef> DelitosRefs { get; set; }

		public virtual ICollection<ExpedientesDelito> ExpedientesDelito { get; set; }

		public virtual ICollection<JuecesSorteo> JuecesSorteo { get; set; }

		public virtual ICollection<PreventivosDelitos> PreventivosDelitos { get; set; }

		[ForeignKey("Capitulo")]
		public virtual DelitosCapituloRef Capitulos { get; set; }
		#endregion

	}
}
