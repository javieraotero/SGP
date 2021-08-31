
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
	[MetadataTypeAttribute(typeof(TransferenciaDeBienesMetaData))]
	[Table("TransferenciaDeBienes")]
	public partial class TransferenciaDeBienes
	{
		#region Constructor
		public TransferenciaDeBienes()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar IdBien")]
		public int IdBien { get; set; }

		public int? Origen { get; set; }

		public int? Destino { get; set; }

		public DateTime? Fecha { get; set; }

		public int? Expediente { get; set; }

		public int? PlanillaDeTransferencia { get; set; }

		public DateTime? FechaDeAlta { get; set; }

		public int? ResponsablePrimario { get; set; }

		public int? ResponsableSecundario { get; set; }

		public int? ResponsableDeUso { get; set; }

		public int? ResponsablePrimarioAnterior { get; set; }

		public int? ResponsableSecundarioAnterior { get; set; }

		public int? ResponsableDeUsoAnterior { get; set; }

		public DateTime? FechaDeCreacion { get; set; }

		public int? Estado { get; set; }

		public bool Control { get; set; }

		public string ExpedienteProvincia { get; set; }

		public int? OrganizacionCreadora { get; set; }
		#endregion

	}
}
