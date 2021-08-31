using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class CesidaMovimientosViewT
	{
        #region Propiedades

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "CodigoCesida")]
        public string CodigoCesida { get; set; }

        [Display(Name = "ApiURLProduccion")]
        public string ApiURLProduccion { get; set; }

        [Display(Name = "ApiURLPruebas")]
        public string ApiURLPruebas { get; set; }
        #endregion


    }
}
