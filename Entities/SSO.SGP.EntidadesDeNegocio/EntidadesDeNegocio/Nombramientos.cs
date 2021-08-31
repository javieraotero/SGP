
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
	[MetadataTypeAttribute(typeof(NombramientosMetaData))]
	[Table("Nombramientos")]
	public partial class Nombramientos
	{
		#region Constructor
		public Nombramientos()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Agente")]
		public int Agente { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaDeAlta")]
		public DateTime FechaDeAlta { get; set; }

		public DateTime? FechaDeBaja { get; set; }

		[StringLength(255, ErrorMessage ="Motivo no puede superar los 255 caracteres")]
		public string Motivo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Organismo")]
		public int Organismo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Cargo")]
		public int Cargo { get; set; }

		[StringLength(2, ErrorMessage ="SituacionRevista no puede superar los 2 caracteres")]
		public string SituacionRevista { get; set; }

		public DateTime? FechaFinContrato { get; set; }

		public DateTime? FechaFinSustitucion { get; set; }

		public DateTime? FechaRenuncia { get; set; }

		public DateTime? FechaPaseAPlanta { get; set; }

		public DateTime? FechaUltimoAscenso { get; set; }

        public DateTime? FechaEliminacion { get; set; }

        public int? Categoria_Cesida { get; set; }

        public int? Designacion_Cesida { get; set; }

        public int? Persona_Cesida { get; set; }

        public int? Ubicacion_Cesida { get; set; }

		[ForeignKey("Agente")]
		public virtual Agentes Agentes { get; set; }

		[ForeignKey("Organismo")]
		public virtual OrganismosRef Organismos { get; set; }

		[ForeignKey("Cargo")]
		public virtual CargosRef Cargos { get; set; }

        [ForeignKey("Categoria_Cesida")]
        public virtual CesidaCategorias Categoria_Cesidas { get; set; }

        [ForeignKey("Ubicacion_Cesida")]
        public virtual CesidaUbicaciones Ubicacion_Cesidas { get; set; }

        public virtual ICollection<NombramientosMovimientos> NombramientosMovimientos{ get; set; }

		#endregion

	}
}
