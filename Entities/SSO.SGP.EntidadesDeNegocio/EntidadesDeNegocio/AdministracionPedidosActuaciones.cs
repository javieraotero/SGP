
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
	[MetadataTypeAttribute(typeof(AdministracionPedidosActuacionesMetaData))]
	[Table("AdministracionPedidosActuaciones")]
	public partial class AdministracionPedidosActuaciones
	{
		#region Constructor
		public AdministracionPedidosActuaciones()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Pedido")]
		public int Pedido { get; set; }       

        [Required(ErrorMessage = "Debe ingresar Descripcion")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

        [Required(ErrorMessage = "Debe ingresar Usuario Alta")]
        public int UsuarioAlta { get; set; }        

        [Required(ErrorMessage = "Debe ingresar Activo")]
		public bool Activo { get; set; }
                
        public DateTime? FechaBaja { get; set; }

        public int? UsuarioBaja { get; set; }
        
        [ForeignKey("Pedido")]
        public virtual AdministracionPedidos Pedidos { get; set; }
        
        #endregion

    }

}
