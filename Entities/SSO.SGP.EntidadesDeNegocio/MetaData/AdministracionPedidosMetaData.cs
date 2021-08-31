using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class AdministracionPedidosMetaData
	{
		#region Propiedades

		[Display(Name = "Id")]
		public int Id { get; set; }        

        [Display(Name = "Organismo Origen")]
		public int OrganismoOrigen { get; set; }

        [Display(Name = "Organismo Destino")]
        public int OrganismoDestino { get; set; }

        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Display(Name = "Fecha Alta")]
		public DateTime FechaAlta { get; set; }

		[Display(Name = "Usuario Alta")]
		public int UsuarioAlta { get; set; }

        [Display(Name = "Numero")]
        public int Numero { get; set; }        

		[Display(Name = "Activo")]
		public bool Activo { get; set; }

        [Display(Name = "Fecha Recepcion")]
        public DateTime? FechaRecepcion { get; set; }

        [Display(Name = "Usuario Recepcion")]
        public int? UsuarioRecepcion { get; set; }

        [Display(Name = "Fecha Rechazado")]
        public DateTime? FechaRechazado { get; set; }

        [Display(Name = "Usuario Rechazado")]
        public int? UsuarioRechazado { get; set; }

        [Display(Name = "Motivo Rechazado")]
        public string MotivoRechazado { get; set; }


        #endregion


    }
}
