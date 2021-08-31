
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
	[MetadataTypeAttribute(typeof(OperacionesContablesRefMetaData))]
	[Table("OperacionesContablesRef")]
	public partial class OperacionesContablesRef
	{
		#region Constructor
		public OperacionesContablesRef()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		[StringLength(50, ErrorMessage ="Descripcion no puede superar los 50 caracteres")]
		public string Descripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Imputa")]
		public bool Imputa { get; set; }

        [Required(ErrorMessage = "Debe ingresar orden ('0' si no corresponde).")]
        public int OrdenContable { get; set; }

		public virtual ICollection<ImputacionesContables> ImputacionesContables { get; set; }
		#endregion

	}
}
