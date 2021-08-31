
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
	[MetadataTypeAttribute(typeof(AdministracionPedidosMetaData))]
	[Table("AdministracionPedidos")]
	public partial class AdministracionPedidos
	{
		#region Constructor
		public AdministracionPedidos()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Organismo Origen")]
		public int OrganismoOrigen { get; set; }

        [Required(ErrorMessage = "Debe ingresar Organismo Destino")]
        public int OrganismoDestino { get; set; }

        [Required(ErrorMessage = "Debe ingresar Descripcion")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

        [Required(ErrorMessage = "Debe ingresar Usuario Alta")]
        public int UsuarioAlta { get; set; }

        [Required(ErrorMessage = "Debe ingresar Numero")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Debe ingresar Activo")]
		public bool Activo { get; set; }
                
        public DateTime? FechaRecepcion { get; set; }

        public int? UsuarioRecepcion { get; set; }

        public DateTime? FechaRechazado { get; set; }

        public int? UsuarioRechazado { get; set; }

        public string MotivoRechazado { get; set; }

        //[ForeignKey("Licencia")]
        //public virtual OrganismosRef Organismo { get; set; }        
        public virtual ICollection<AdministracionPedidosActuaciones> AdministracionPedidosActuaciones { get; set; }

        [ForeignKey("OrganismoOrigen")]
        public virtual OrganismosRef OrganismosOrigenRef { get; set; }

        [ForeignKey("OrganismoDestino")]
        public virtual OrganismosRef OrganismosRef { get; set; }

        #endregion

    }

}
