using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class AdministracionPedidosActuacionesMetaData
	{
		#region Propiedades

		[Display(Name = "Id")]
		public int Id { get; set; }        

        [Display(Name = "Pedido")]
		public int Pedido { get; set; }        

        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Display(Name = "Fecha Alta")]
		public DateTime FechaAlta { get; set; }

		[Display(Name = "Usuario Alta")]
		public int UsuarioAlta { get; set; }             

		[Display(Name = "Activo")]
		public bool Activo { get; set; }

        [Display(Name = "Fecha Baja")]
        public DateTime? FechaBaja { get; set; }

        [Display(Name = "Usuario Baja")]
        public int? UsuarioBaja { get; set; }

        #endregion
        
    }
}
