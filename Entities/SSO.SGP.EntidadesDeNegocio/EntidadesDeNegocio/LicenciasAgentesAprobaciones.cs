
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
	//[MetadataTypeAttribute(typeof(BarriosRefMetaData))]
	[Table("LicenciasAgentesAprobaciones")]
	public partial class LicenciasAgentesAprobaciones
    {
		#region Constructor
		public LicenciasAgentesAprobaciones()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }
		public int Licencia { get; set; }
		public int AgenteAprueba { get; set; }
        public bool Aprobado { get; set; }
        public DateTime? FechaAprobado { get; set; }
        public DateTime FechaAlta { get; set; }

		#endregion

	}
}
