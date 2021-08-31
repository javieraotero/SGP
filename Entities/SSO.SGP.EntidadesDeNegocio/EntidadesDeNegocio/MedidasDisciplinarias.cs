
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
	[MetadataTypeAttribute(typeof(MedidasDisciplinariasMetaData))]
	[Table("MedidasDisciplinarias")]
	public partial class MedidasDisciplinarias
	{
		#region Constructor
		public MedidasDisciplinarias()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Agente")]
		public int Agente { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fecha")]
		public DateTime Fecha { get; set; }

		[Required(ErrorMessage = "Debe ingresar Causa")]
		[StringLength(255, ErrorMessage ="Causa no puede superar los 255 caracteres")]
		public string Causa { get; set; }

		[ForeignKey("Agente")]
		public virtual Agentes Agentes { get; set; }
		#endregion

	}
}
