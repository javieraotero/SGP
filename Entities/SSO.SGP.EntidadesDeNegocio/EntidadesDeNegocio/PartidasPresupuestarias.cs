
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
	[MetadataTypeAttribute(typeof(PartidasPresupuestariasMetaData))]
	[Table("PartidasPresupuestarias")]
	public partial class PartidasPresupuestarias
	{
		#region Constructor
		public PartidasPresupuestarias()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar NumeroDePartida")]
		[StringLength(4, ErrorMessage ="NumeroDePartida no puede superar los 4 caracteres")]
		public string NumeroDePartida { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		[StringLength(50, ErrorMessage ="Descripcion no puede superar los 50 caracteres")]
		public string Descripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Mnemo")]
		[StringLength(50, ErrorMessage ="Mnemo no puede superar los 50 caracteres")]
		public string Mnemo { get; set; }

		[Required(ErrorMessage = "Debe ingresar UnidadDeOrganizacion")]
		public int UnidadDeOrganizacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Prioridad")]
		public bool Prioridad { get; set; }

        public DateTime? FechaElimina { get; set; }

        public int? UsuarioElimina { get; set; }

		public virtual ICollection<DivisionesExtraPresupuestarias> DivisionesExtraPresupuestarias { get; set; }

        //public virtual ICollection<EjecucionesPresupuestarias> EjecucionesPresupuestarias { get; set; }

        //public virtual ICollection<FacturasImputadasDetalle> FacturasImputadasDetalle { get; set; }

        [ForeignKey("UnidadDeOrganizacion")]
		public virtual UnidadesDeOrganizacionRef UnidadDeOrganizacions { get; set; }
		#endregion

	}
}
