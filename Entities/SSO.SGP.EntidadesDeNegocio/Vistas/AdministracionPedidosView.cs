using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
    /// <summary>
    /// Vista generada por generador de codigo
    /// </summary>
    public class AdministracionPedidosView
    {
        #region Propiedades

        [Display(Name = "Id", AutoGenerateField = false, Order = 0)]
        public int Id { get; set; }

        [Display(Name = "Numero", Order = 5)]
        public int Numero { get; set; }

        [Display(Name = "OrganismoOrigen_Hide", Order = 5)]
        public int OrganismoOrigen_Hide { get; set; }

        [Display(Name = "OrganismoDestino", Order = 35)]
        public string OrganismoDestino { get; set; }

        [Display(Name = "Descripcion", Order = 50)]
        public string Descripcion { get; set; }

        [Display(Name = "FechaAlta", Order = 5)]
        public DateTime FechaAlta { get; set; }

        [Display(Name = "UsuarioAlta_Hide", Order = 0)]
        public int UsuarioAlta { get; set; }
        

        //[Display(Name = "Activo",  Order = 0)]
        //public bool Activo { get; set; }

        
        #endregion
    }

    public class AdministracionPedidosSolicitudesView
    {
        #region Propiedades

        [Display(Name = "Id", AutoGenerateField = false, Order = 0)]
        public int Id { get; set; }

        [Display(Name = "Numero", Order = 5)]
        public int Numero { get; set; }

        [Display(Name = "OrganismoOrigen", Order = 35)]
        public string OrganismoOrigen { get; set; }

        [Display(Name = "OrganismoDestino_Hide", Order = 5)]
        public int OrganismoDestino_Hide { get; set; }

        [Display(Name = "Descripcion", Order = 50)]
        public string Descripcion { get; set; }

        [Display(Name = "FechaAlta", Order = 5)]
        public DateTime FechaAlta { get; set; }

        [Display(Name = "UsuarioAlta_Hide", Order = 0)]
        public int UsuarioAlta { get; set; }


        //[Display(Name = "Activo",  Order = 0)]
        //public bool Activo { get; set; }


        #endregion
    }

    public class AdministracionPedidosViewMM
    {
        #region Propiedades

        [Display(Name = "Id", AutoGenerateField = false, Order = 0)]
        public int Id { get; set; }

        [Display(Name = "OrganismoOrigen", Order = 5)]
        public int OrganismoOrigen { get; set; }

        [Display(Name = "Descripcion", Order = 25)]
        public string Descripcion { get; set; }
        
        #endregion
    }
}
