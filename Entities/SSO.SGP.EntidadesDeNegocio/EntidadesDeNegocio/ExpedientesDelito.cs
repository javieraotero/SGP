
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
	[MetadataTypeAttribute(typeof(ExpedientesDelitoMetaData))]
	[Table("ExpedientesDelito")]
	public partial class ExpedientesDelito
	{
		#region Constructor
		public ExpedientesDelito()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Expediente")]
		public int Expediente { get; set; }

		[Required(ErrorMessage = "Debe ingresar Delito")]
		public int Delito { get; set; }

		public DateTime? FechaDesde { get; set; }

		public DateTime? FechaHasta { get; set; }

		[StringLength(5, ErrorMessage ="HoraDesde no puede superar los 5 caracteres")]
		public string HoraDesde { get; set; }

		[StringLength(5, ErrorMessage ="HoraHasta no puede superar los 5 caracteres")]
		public string HoraHasta { get; set; }

		public int? Barrio { get; set; }

		public int? Calle { get; set; }

		public int? Calle1 { get; set; }

		public int? Calle2 { get; set; }

		public int? Nro { get; set; }

		[StringLength(255, ErrorMessage ="DescripcionUbicacion no puede superar los 255 caracteres")]
		public string DescripcionUbicacion { get; set; }

		[StringLength(8000, ErrorMessage ="Observaciones no puede superar los 8000 caracteres")]
		public string Observaciones { get; set; }

		[Required(ErrorMessage = "Debe ingresar CantidadHechos")]
		public int CantidadHechos { get; set; }

		[Required(ErrorMessage = "Debe ingresar Tentativa")]
		public bool Tentativa { get; set; }

		[Required(ErrorMessage = "Debe ingresar UbicacionExacta")]
		public bool UbicacionExacta { get; set; }

		[Required(ErrorMessage = "Debe ingresar Flagrancia")]
		public bool Flagrancia { get; set; }

		public int? Localidad { get; set; }

		public bool? Activo { get; set; }

		public DateTime? FechaAlta { get; set; }

		public int? UsuarioAlta { get; set; }

		public DateTime? FechaModificacion { get; set; }

		public int? UsuarioModificacion { get; set; }

		public DateTime? FechaBaja { get; set; }

		public int? UsuarioBaja { get; set; }

		public virtual ICollection<ActuacionesPersonaDelito> ActuacionesPersonaDelito { get; set; }

		[ForeignKey("Expediente")]
		public virtual Expedientes Expedientes { get; set; }

		[ForeignKey("Delito")]
		public virtual DelitosRef Delitos { get; set; }

		[ForeignKey("Barrio")]
		public virtual BarriosRef Barrios { get; set; }

		[ForeignKey("Calle")]
		public virtual CallesRef Calles { get; set; }

		[ForeignKey("Calle1")]
		public virtual CallesRef Calle1s { get; set; }

		[ForeignKey("Calle2")]
		public virtual CallesRef Calle2s { get; set; }

		[ForeignKey("Localidad")]
		public virtual LocalidadesRef Localidads { get; set; }

		[ForeignKey("UsuarioAlta")]
		public virtual Usuarios UsuarioAltas { get; set; }

		[ForeignKey("UsuarioModificacion")]
		public virtual Usuarios UsuarioModificacions { get; set; }

		[ForeignKey("UsuarioBaja")]
		public virtual Usuarios UsuarioBajas { get; set; }
		#endregion

	}
}
