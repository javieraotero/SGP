
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
	[MetadataTypeAttribute(typeof(PreventivosMetaData))]
	[Table("Preventivos")]
	public partial class Preventivos
	{
		#region Constructor
		public Preventivos()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Numero")]
		[StringLength(10, ErrorMessage ="Numero no puede superar los 10 caracteres")]
		public string Numero { get; set; }

		[Required(ErrorMessage = "Debe ingresar Comisaria")]
		public int Comisaria { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaDenuncia")]
		public DateTime FechaDenuncia { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaHecho")]
		public DateTime FechaHecho { get; set; }

		[Required(ErrorMessage = "Debe ingresar Caratula")]
		[StringLength(255, ErrorMessage ="Caratula no puede superar los 255 caracteres")]
		public string Caratula { get; set; }

		[Required(ErrorMessage = "Debe ingresar AlertaActiva")]
		public bool AlertaActiva { get; set; }

		[Required(ErrorMessage = "Debe ingresar Estado")]
		public int Estado { get; set; }

		[StringLength(8000, ErrorMessage ="Reclamo no puede superar los 8000 caracteres")]
		public string Reclamo { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioAlta")]
		public int UsuarioAlta { get; set; }

		public DateTime? FechaRecepcion { get; set; }

		public int? UsuarioRecepcion { get; set; }

		public DateTime? FechaAnulado { get; set; }

		public int? UsuarioAnulado { get; set; }

		[Required(ErrorMessage = "Debe ingresar Confirmado")]
		public bool Confirmado { get; set; }

		public bool? Bloqueado { get; set; }

		public int? UsuarioBloquea { get; set; }

		public DateTime? FechaBloqueo { get; set; }

		[Required(ErrorMessage = "Debe ingresar AutoresIgnorados")]
		public bool AutoresIgnorados { get; set; }

		[StringLength(255, ErrorMessage ="Ubicacion no puede superar los 255 caracteres")]
		public string Ubicacion { get; set; }

		public int? Firmante { get; set; }

		[StringLength(20, ErrorMessage ="NroPreventivoPolicia no puede superar los 20 caracteres")]
		public string NroPreventivoPolicia { get; set; }

		[StringLength(20, ErrorMessage ="NroSumarioPolicia no puede superar los 20 caracteres")]
		public string NroSumarioPolicia { get; set; }

		public int? Sector { get; set; }

		public int? Sitio { get; set; }

		[Required(ErrorMessage = "Debe ingresar JusticiaProvincial")]
		public int JusticiaProvincial { get; set; }

		public int? Modalidad { get; set; }

		public int? Calle { get; set; }

		[StringLength(50, ErrorMessage ="Altura no puede superar los 50 caracteres")]
		public string Altura { get; set; }

		public virtual ICollection<Actuaciones> Actuaciones { get; set; }

		public virtual ICollection<Denuncias> Denuncias { get; set; }

		public virtual ICollection<Expedientes> Expedientes { get; set; }

		[ForeignKey("Comisaria")]
		public virtual OrganismosRef Comisarias { get; set; }

		[ForeignKey("Estado")]
		public virtual EstadosPreventivoRef Estados { get; set; }

		[ForeignKey("UsuarioAlta")]
		public virtual Usuarios UsuarioAltas { get; set; }

		[ForeignKey("UsuarioRecepcion")]
		public virtual Usuarios UsuarioRecepcions { get; set; }

		[ForeignKey("UsuarioAnulado")]
		public virtual Usuarios UsuarioAnulados { get; set; }

		[ForeignKey("Firmante")]
		public virtual Usuarios Firmantes { get; set; }

		[ForeignKey("Sector")]
		public virtual SectoresPoliciaRef Sectors { get; set; }

		[ForeignKey("Sitio")]
		public virtual SitiosPoliciaRef Sitios { get; set; }

		[ForeignKey("Modalidad")]
		public virtual ModalidadesPoliciaRef Modalidads { get; set; }

		[ForeignKey("Calle")]
		public virtual CallesRef Calles { get; set; }
		#endregion

	}
}
