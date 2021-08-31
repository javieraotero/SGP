using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ECO_ProveedoresEconomiaView
    {
        #region Propiedades

        [Display(Name = "Id", Order = 0)]
        public int Id { get; set; }
        [Display(Name = "Razón Social", Order = 18)]
        public string RazonSocial { get; set; }
        [Display(Name = "Tipo", Order = 12)]
        public string TipoProveedor { get; set; }
        [Display(Name = "CUIT", Order = 8)]
        public string CUIT { get; set; }
        [Display(Name = "Provincia", Order = 12)]
        public string Provincia { get; set; }
        [Display(Name = "Localidad", Order = 12)]
        public string Localidad { get; set; }
        [Display(Name = "Dom. Electr.", Order = 12)]
        public string DomicilioElectronico { get; set; }
        [Display(Name = "Dom. Postal", Order = 15)]
        public string DomicilioPostal { get; set; }
        [Display(Name = "Tel.", Order = 5)]
        public string TelefonoMovil { get; set; }
        [Display(Name = "Inscripto", Order = 8)]
        public string InscriptoLaPampa { get; set; }
        [Display(Name = "Fecha Carga", Order = 8)]
        public DateTime FechaAlta { get; set; }
        [Display(Name = "Estado", Order = 12)]
        public string Estado { get; set; }
        [Display(Name = "Acciones", Order = 5)]
        public string operaciones { get; set; }

        #endregion


    }

}
