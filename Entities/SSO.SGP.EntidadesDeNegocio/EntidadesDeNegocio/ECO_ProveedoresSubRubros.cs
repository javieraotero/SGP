
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SSO.SGP.MetaData;


namespace SSO.SGP.EntidadesDeNegocio
{
	//[MetadataTypeAttribute(typeof(TurnosWebParametrosMetaData))]
	[Table("ECO_ProveedoresSubRubros")]
	public partial class ECO_ProveedoresSubRubros
	{
		#region Constructor
		public ECO_ProveedoresSubRubros()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }
		public int Proveedor { get; set; }
		public int SubRubro { get; set; }


        //[ForeignKey("Proveedor")]
        //public virtual ECO_Proveedores Proveedor_ { get; set; }
        [ForeignKey("SubRubro")]
        public virtual ECO_ProveedoresSubRubroRef SubRubro_ { get; set; }
        #endregion

    }
}
