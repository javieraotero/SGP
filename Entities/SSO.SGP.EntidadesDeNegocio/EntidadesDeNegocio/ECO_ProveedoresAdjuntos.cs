
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
	//[MetadataTypeAttribute(typeof(TurnosWebParametrosMetaData))]
	[Table("ECO_ProveedoresAdjuntos")]
	public partial class ECO_ProveedoresAdjuntos
	{
		#region Constructor
		public ECO_ProveedoresAdjuntos()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }
		[MaxLength(150)]
		public string URL { get; set; }
		public eDocumentosProveedores TipoAdjunto { get; set; }
		public DateTime FechaAlta { get; set; }
		public bool Activo { get; set; }
		public int Proveedor { get; set; }
        public int Rectificacion { get; set; }

		[ForeignKey("Proveedor")]
		public virtual ECO_Proveedores Proveedor_{ get; set; }
		#endregion

	}
}
