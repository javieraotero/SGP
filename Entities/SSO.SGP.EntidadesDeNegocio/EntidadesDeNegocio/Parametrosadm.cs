
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
	[MetadataTypeAttribute(typeof(ParametrosadmMetaData))]
	[Table("Parametrosadm")]
	public partial class Parametrosadm
	{
		#region Constructor
		public Parametrosadm()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar UltimoExpediente")]
		public int UltimoExpediente { get; set; }

		[Required(ErrorMessage = "Debe ingresar UltimaFactura")]
		public int UltimaFactura { get; set; }

		[Required(ErrorMessage = "Debe ingresar UltimoTramite")]
		public int UltimoTramite { get; set; }

        [Required(ErrorMessage = "Debe ingresar Unidad de Organización")]
        public int UnidadDeOrganizacion { get; set; }
        
        public int? UltimoLegajo { get; set; }

        public int? UltimaComision { get; set; }

        #endregion

    }
}
