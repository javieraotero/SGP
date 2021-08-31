
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
	[MetadataTypeAttribute(typeof(GrupoFamiliarMetaData))]
	[Table("GrupoFamiliar")]
	public partial class GrupoFamiliar
	{
		#region Constructor
		public GrupoFamiliar()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Agente")]
		public int Agente { get; set; }

		[Required(ErrorMessage = "Debe ingresar ApellidosYNombre")]
		[StringLength(40, ErrorMessage ="ApellidosYNombre no puede superar los 40 caracteres")]
		public string ApellidosYNombre { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaDeNacimiento")]
		public DateTime FechaDeNacimiento { get; set; }

		[Required(ErrorMessage = "Debe ingresar Documento")]
		public int Documento { get; set; }

		[Required(ErrorMessage = "Debe ingresar TipoMiembro")]
		public int TipoMiembro { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activo")]
		public bool Activo { get; set; }

		public DateTime? FechaBaja { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

        public long? PersonaNucleo { get; set; }

        [ForeignKey("Agente")]
		public virtual Agentes Agentes { get; set; }

		[ForeignKey("TipoMiembro")]
		public virtual TiposParentescosRef TipoMiembros { get; set; }
		#endregion

	}
}
