
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
	[MetadataTypeAttribute(typeof(DivisionesExtraPresupuestariasMetaData))]
	[Table("DivisionesExtraPresupuestarias")]
	public partial class DivisionesExtraPresupuestarias
	{
		#region Constructor
		public DivisionesExtraPresupuestarias()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Nombre")]
		[StringLength(100, ErrorMessage ="Nombre no puede superar los 100 caracteres")]
		public string Nombre { get; set; }

		[Required(ErrorMessage = "Debe ingresar CodigoCESIDA")]
		[StringLength(5, ErrorMessage ="CodigoCESIDA no puede superar los 5 caracteres")]
		public string CodigoCESIDA { get; set; }

		[Required(ErrorMessage = "Debe ingresar PartidaPresupuestaria")]
		public int PartidaPresupuestaria { get; set; }

        //public virtual ICollection<FacturasImputadasDetalle> FacturasImputadasDetalle { get; set; }
         
        [ForeignKey("PartidaPresupuestaria")]
        public virtual PartidasPresupuestarias PartidaPresupuestarias { get; set; }
        #endregion

    }
}
