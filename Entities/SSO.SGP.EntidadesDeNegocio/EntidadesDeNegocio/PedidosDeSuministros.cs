
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
	[MetadataTypeAttribute(typeof(PedidosDeSuministrosMetaData))]
	[Table("PedidosDeSuministros")]
	public partial class PedidosDeSuministros
	{
		#region Constructor
		public PedidosDeSuministros()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Organismo")]
		public int Organismo { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaDePedido")]
		public DateTime FechaDePedido { get; set; }

		public int? Usuario { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaDeCarga")]
		public DateTime FechaDeCarga { get; set; }

		[Required(ErrorMessage = "Debe ingresar Entregado")]
		public bool Entregado { get; set; }

		public DateTime? FechaDeBaja { get; set; }

		public int? UsuarioBaja { get; set; }

		public virtual ICollection<ArticulosDePedidoDeSuministros> ArticulosDePedidoDeSuministros { get; set; }

		//public virtual ICollection<MovimientosDeStock> MovimientosDeStock { get; set; }

		[ForeignKey("Organismo")]
		public virtual OrganismosRef Organismos { get; set; }

		[ForeignKey("Usuario")]
		public virtual Usuarios Usuarios { get; set; }

		[ForeignKey("UsuarioBaja")]
		public virtual Usuarios UsuarioBajas { get; set; }
		#endregion

	}

}
