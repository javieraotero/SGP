using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class AdministracionPedidosViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "OrganismoOrigen")]
			public int OrganismoOrigen { get; set; }

        [Display(Name = "OrganismoDestino")]
        public int OrganismoDestino { get; set; }

        [Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

        [Display(Name = "FechaAlta")]
        public DateTime FechaAlta { get; set; }

        [Display(Name = "UsuarioAlta")]
        public int UsuarioAlta { get; set; }

        [Display(Name = "Numero")]
        public int Numero { get; set; }

        [Display(Name = "Activo")]
        public bool Activo { get; set; }

        
        #endregion


    }
}
