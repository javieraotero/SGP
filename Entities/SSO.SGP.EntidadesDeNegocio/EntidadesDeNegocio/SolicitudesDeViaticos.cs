
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
	[MetadataTypeAttribute(typeof(SolicitudesDeViaticosMetaData))]
	[Table("SolicitudesDeViaticos")]
	public partial class SolicitudesDeViaticos
	{
		#region Constructor
		public SolicitudesDeViaticos()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fecha")]
		public DateTime Fecha { get; set; }

		[Required(ErrorMessage = "Debe ingresar OrganismoSolicitante")]
		public int OrganismoSolicitante { get; set; }

		[Required(ErrorMessage = "Debe ingresar Destino")]
		public int Destino { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaDeInicio")]
		public DateTime FechaDeInicio { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaDeFin")]
		public DateTime FechaDeFin { get; set; }

		[Required(ErrorMessage = "Debe ingresar MedioDeTransporte")]
		public int MedioDeTransporte { get; set; }

		public int? AutoOficial { get; set; }

		[Required(ErrorMessage = "Debe ingresar ConChofer")]
		public bool ConChofer { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioAlta")]
		public int UsuarioAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaModifica")]
		public DateTime FechaModifica { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioModifica")]
		public int UsuarioModifica { get; set; }

		[Required(ErrorMessage = "Debe ingresar Estado")]
		public int Estado { get; set; }

		[Required(ErrorMessage = "Debe ingresar MotivoDeComision")]
		public string MotivoDeComision { get; set; }

		public string Expediente { get; set; }

		[Required(ErrorMessage = "Debe ingresar Identificador")]
		public int Identificador { get; set; }

        public string Patente { get; set; }

        public string TipoVehiculo { get; set; }

        public string VigenciaSeguro { get; set; }

        public string Seguro { get; set; }

        public bool Anticipo { get; set; }

        public int? Comision { get; set; }

        public bool SolicitaAnticipo { get; set; }

		public virtual ICollection<SolicitudesDeViaticosAgentes> SolicitudesDeViaticosAgentes { get; set; }

		public virtual ICollection<SolicitudesDeViaticosRendiciones> SolicitudesDeViaticosRendiciones { get; set; }
		#endregion

	}
}
