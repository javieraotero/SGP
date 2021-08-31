
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
	[MetadataTypeAttribute(typeof(SucesosMetaData))]
	[Table("Sucesos")]
	public partial class Sucesos
	{
		#region Constructor
		public Sucesos()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioAlta")]
		public int UsuarioAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar SubAmbito")]
		public int SubAmbito { get; set; }

		[Required(ErrorMessage = "Debe ingresar Titulo")]
		public int Titulo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		[StringLength(2147483647, ErrorMessage ="Descripcion no puede superar los 2147483647 caracteres")]
		public string Descripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar TiposSuceso")]
		public int TiposSuceso { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaMostrar")]
		public DateTime FechaMostrar { get; set; }

		[Required(ErrorMessage = "Debe ingresar TareaRealizada")]
		public bool TareaRealizada { get; set; }

		public DateTime? FechaRealizada { get; set; }

		public int? UsuarioRealizada { get; set; }

		public int? Expediente { get; set; }

		public int? Actuacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activa")]
		public bool Activa { get; set; }

		public DateTime? FechaEliminacion { get; set; }

		public int? UsuarioEliminacion { get; set; }

		public int? ResponsableEvento { get; set; }

		public int? OficinaEvento { get; set; }

		[Required(ErrorMessage = "Debe ingresar ModificadoPorSuspension")]
		public bool ModificadoPorSuspension { get; set; }

		[ForeignKey("SubAmbito")]
		public virtual Ambitos SubAmbitos { get; set; }

		[ForeignKey("Titulo")]
		public virtual SucesosTitulos Titulos { get; set; }

		[ForeignKey("TiposSuceso")]
		public virtual TiposSucesos TiposSucesos { get; set; }

		[ForeignKey("Expediente")]
		public virtual Expedientes Expedientes { get; set; }

		[ForeignKey("Actuacion")]
		public virtual Actuaciones Actuacions { get; set; }

		[ForeignKey("OficinaEvento")]
		public virtual OrganismosRef OficinaEventos { get; set; }
		#endregion

	}
}
