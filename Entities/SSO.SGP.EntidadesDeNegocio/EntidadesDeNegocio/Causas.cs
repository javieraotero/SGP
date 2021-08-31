
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
	[MetadataTypeAttribute(typeof(CausasMetaData))]
	[Table("Causas")]
	public partial class Causas
	{
		#region Constructor
		public Causas()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		public int? Numero { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fecha")]
		public DateTime Fecha { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaPresentacion")]
		public DateTime FechaPresentacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Caratula")]
		[StringLength(455, ErrorMessage ="Caratula no puede superar los 455 caracteres")]
		public string Caratula { get; set; }

		[StringLength(455, ErrorMessage ="Autos no puede superar los 455 caracteres")]
		public string Autos { get; set; }

		public int? JuzgadoSorteo { get; set; }

		public int? Juzgado { get; set; }

		public int? Categoria { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fuero")]
		[StringLength(1, ErrorMessage ="Fuero no puede superar los 1 caracteres")]
		public string Fuero { get; set; }

		[Required(ErrorMessage = "Debe ingresar Materia")]
		public int Materia { get; set; }

		[Required(ErrorMessage = "Debe ingresar Reserva")]
		public bool Reserva { get; set; }

		public int? CausaMadre { get; set; }

		public int? AnioCausaMadre { get; set; }

		public decimal? Monto { get; set; }

		[StringLength(20, ErrorMessage ="ReciboCajaForense no puede superar los 20 caracteres")]
		public string ReciboCajaForense { get; set; }

		public decimal? MontoCajaForense { get; set; }

		[StringLength(20, ErrorMessage ="ReciboRentas no puede superar los 20 caracteres")]
		public string ReciboRentas { get; set; }

		public decimal? MontoRentas { get; set; }

		[StringLength(100, ErrorMessage ="Origen no puede superar los 100 caracteres")]
		public string Origen { get; set; }

		[StringLength(20, ErrorMessage ="Ciudad no puede superar los 20 caracteres")]
		public string Ciudad { get; set; }

		public int? Provincia { get; set; }

		[StringLength(255, ErrorMessage ="ASolicitudDe no puede superar los 255 caracteres")]
		public string ASolicitudDe { get; set; }

		[Required(ErrorMessage = "Debe ingresar Confirmada")]
		public bool Confirmada { get; set; }

		public int? Estado { get; set; }

		[Required(ErrorMessage = "Debe ingresar Circunscripcion")]
		public int Circunscripcion { get; set; }

		public int? Mediador { get; set; }

		public int? CoMediador { get; set; }

		[Required(ErrorMessage = "Debe ingresar GenCuentaBancaria")]
		public bool GenCuentaBancaria { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioRecepciono")]
		public int UsuarioRecepciono { get; set; }

		public int? EspecialidadCoMediador { get; set; }

		[StringLength(2147483647, ErrorMessage ="Demanda no puede superar los 2147483647 caracteres")]
		public string Demanda { get; set; }

		public int? ModeloAplicado { get; set; }

		[StringLength(20, ErrorMessage ="ReciboTRMed no puede superar los 20 caracteres")]
		public string ReciboTRMed { get; set; }

		public decimal? MontoTRMed { get; set; }

		[StringLength(500, ErrorMessage ="Observaciones no puede superar los 500 caracteres")]
		public string Observaciones { get; set; }

		public int? OrganismoRecepciono { get; set; }

		public bool? QuiebraAbierta { get; set; }

		public bool? QuiebraConcluida { get; set; }

		public virtual ICollection<ActuacionesCivil> ActuacionesCivil { get; set; }

		public virtual ICollection<AudienciasCivil> AudienciasCivil { get; set; }

		public virtual ICollection<CambiosRadicacion> CambiosRadicacion { get; set; }

		[ForeignKey("JuzgadoSorteo")]
		public virtual OrganismosRef JuzgadoSorteos { get; set; }

		[ForeignKey("Juzgado")]
		public virtual OrganismosRef Juzgados { get; set; }

		[ForeignKey("Categoria")]
		public virtual CategoriasCausas Categorias { get; set; }

		[ForeignKey("Materia")]
		public virtual Materias Materias { get; set; }

		[ForeignKey("Provincia")]
		public virtual ProvinciasRef Provincias { get; set; }

		[ForeignKey("Estado")]
		public virtual EstadosCausaRef Estados { get; set; }

		[ForeignKey("Circunscripcion")]
		public virtual CircunscripcionesRef Circunscripcions { get; set; }

		[ForeignKey("Mediador")]
		public virtual Usuarios Mediadors { get; set; }

		[ForeignKey("CoMediador")]
		public virtual Usuarios CoMediadors { get; set; }

		[ForeignKey("UsuarioRecepciono")]
		public virtual Usuarios UsuarioRecepcionos { get; set; }

		[ForeignKey("EspecialidadCoMediador")]
		public virtual CoMediadoresEspecialidad EspecialidadCoMediadors { get; set; }
		#endregion

	}
}
