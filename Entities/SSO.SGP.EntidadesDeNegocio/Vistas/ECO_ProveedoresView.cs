using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ECO_ProveedoresView
	{
        #region Propiedades

        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public eTiposProveedores TipoProveedor { get; set; }
        public string CUIT { get; set; }
        public int Provincia { get; set; }
        public int Localidad { get; set; }
        public string DomicilioElectronico { get; set; }
        public string DomicilioPostal { get; set; }
        public string TelefonoMovil { get; set; }
        public bool InscriptoLaPampa { get; set; }
        public DateTime FechaAlta { get; set; }

        public int IdUsuario { get; set; }
        #endregion


    }

}
