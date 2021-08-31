using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class OrganismosRefViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "TipoOrganismo")]
			public int TipoOrganismo { get; set; }

			[Display(Name = "Localidad")]
			public int? Localidad { get; set; }

			[Display(Name = "Abreviatura")]
			public string Abreviatura { get; set; }

			[Display(Name = "DependeDe")]
			public int? DependeDe { get; set; }

			[Display(Name = "Circunscripcion")]
			public int? Circunscripcion { get; set; }

			[Display(Name = "UltimoPreventivo")]
			public int UltimoPreventivo { get; set; }

			[Display(Name = "Domicilio")]
			public string Domicilio { get; set; }

			[Display(Name = "Telefono")]
			public string Telefono { get; set; }

			[Display(Name = "HorarioAtencion")]
			public string HorarioAtencion { get; set; }

			[Display(Name = "SubAmbito")]
			public int? SubAmbito { get; set; }

			[Display(Name = "Fuero")]
			public int Fuero { get; set; }

			[Display(Name = "EncabezadoPDF")]
			public string EncabezadoPDF { get; set; }

			[Display(Name = "ParaNotificaciones")]
			public bool ParaNotificaciones { get; set; }

			[Display(Name = "RecibeNotificaciones")]
			public bool RecibeNotificaciones { get; set; }

			[Display(Name = "ReceptoriaDeCausas")]
			public bool ReceptoriaDeCausas { get; set; }
			#endregion


	}
}
