
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
	[MetadataTypeAttribute(typeof(ImputacionesContablesDetalleMetaData))]
	[Table("ImputacionesContablesDetalle")]
	public partial class ImputacionesContablesDetalle
	{
		#region Constructor
		public ImputacionesContablesDetalle()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar ImputacionContable")]
		public int ImputacionContable { get; set; }

		[Required(ErrorMessage = "Anio contable debe tener un valor")]
		public int AnioContable { get; set; }

		[Required(ErrorMessage = "Debe ingresar Division")]
		public int Division { get; set; }

		[Required(ErrorMessage = "Debe ingresar Importe")]
		public decimal Importe { get; set; }

		[Required(ErrorMessage = "Debe ingresar Usuario")]
		public int Usuario { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fecha")]
		public DateTime Fecha { get; set; }

		public DateTime? FechaElimina { get; set; }

		public int? UsuarioElimina { get; set; }

        public int Partida { get; set; }

		[ForeignKey("ImputacionContable")]
		public virtual ImputacionesContables ImputacionContables { get; set; }

        [ForeignKey("Division")]
        public virtual DivisionesExtraPresupuestarias Divisions { get; set; }

        [ForeignKey("Partida")]
        public virtual PartidasPresupuestarias Partidas{ get; set; }

        #endregion

    }
}
